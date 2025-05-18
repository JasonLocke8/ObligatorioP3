using Libreria.DTOs.DTOs.DTOsSeguimientoEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUSeguimiento;
using Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions;
using Libreria.LogicaNegocio.CustomExceptions.SeguimientoExceptions;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUSeguimientoEnvio
{
    public class CUAgregarSeguimiento : ICUAgregarSeguimiento
    {
        private IRepositorioSeguimientoEnvio _repositorioSeguimiento;
        private IRepositorioEnvio _repositorioEnvio;
        private IRepositorioUsuario _repositorioUsuario;
        private IRepositorioAuditoria _repositorioAuditoria;

        public CUAgregarSeguimiento(IRepositorioSeguimientoEnvio repositorioSeguimiento, IRepositorioEnvio repositorioEnvio, IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioSeguimiento = repositorioSeguimiento;
            _repositorioEnvio = repositorioEnvio;
            _repositorioUsuario = repositorioUsuario;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void AgregarSeguimiento(DTOSeguimientoEnvio seguimiento)

        {
            try
            {
                // Validar que el seguimiento no sea nulo
                if (seguimiento == null)
                {
                    throw new SeguimientoVacioException("El seguimiento está vacío.");
                }

                // Mappear el dto a la entidad
                SeguimientoEnvio seguimientoEnvio = MapperSeguimientoEnvio.FromDTOSeguimientoToSeguimiento(seguimiento);

                // Agrego el envio

                Usuario empleado = _repositorioUsuario.FindById(seguimiento.IdEmpleado);

                if (empleado == null)
                {
                    throw new UsuarioNoExisteException("El empleado no existe.");
                }


                Envio envio = _repositorioEnvio.FindById(seguimiento.EnvioId);

                if (envio == null)
                {
                    throw new EnvioNoExisteException("El envío no existe.");
                }

                // Asignar el empleado al seguimiento
                seguimientoEnvio.ComentarioEmpleado = empleado;

                // Asignar el envio al seguimiento
                seguimientoEnvio.Envio = envio;

                _repositorioSeguimiento.Add(seguimientoEnvio);

                Auditoria aud = new Auditoria(seguimiento.IdEmpleado, "ALTA", "SEGUIMIENTO", seguimientoEnvio.Envio.ClienteId.ToString(), JsonSerializer.Serialize(seguimientoEnvio));
                _repositorioAuditoria.Auditar(aud);

            }
            catch (Exception e)
            {
                Auditoria aud = new Auditoria(seguimiento.IdEmpleado, "ALTA", "SEGUIMIENTO", null, e.Message);
                _repositorioAuditoria.Auditar(aud);

                throw e;
            }


        }
    }
}
