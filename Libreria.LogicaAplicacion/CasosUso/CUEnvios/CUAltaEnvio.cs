using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions;
using System.Text.Json;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvios
{
    public class CUAltaEnvio : ICUAltaEnvio
    {
        private IRepositorioEnvio _repositorioEnvio;
        private IRepositorioUsuario _repositorioUsuario;
        private IRepositorioAgencia _repositorioAgencia;
        private IRepositorioAuditoria _repositorioAuditoria;

        public CUAltaEnvio(IRepositorioAuditoria repositorioAuditoria, IRepositorioEnvio repositorioEnvio , IRepositorioUsuario repositorioUsuario, IRepositorioAgencia repositorioAgencia)
        {
            _repositorioEnvio = repositorioEnvio;
            _repositorioUsuario = repositorioUsuario;
            _repositorioAgencia = repositorioAgencia;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void AltaEnvio(DTOAltaEnvio dtoEnvio)
        {
            try
            {

                Usuario cliente = _repositorioUsuario.FindById(dtoEnvio.ClienteId);
                Usuario empleado = _repositorioUsuario.FindById((int)dtoEnvio.LogueadoId);

                if (cliente == null) throw new UsuarioNoExisteException("El cliente no existe.");
                if (empleado == null) throw new UsuarioNoExisteException("El empleado no existe.");

                Envio envio = MapperEnvio.FromDTOAltaEnvioToEnvio(dtoEnvio);

                if (dtoEnvio.AgenciaDestinoId.HasValue)
                {
                    Agencia agenciaDestino = null;
                    agenciaDestino = _repositorioAgencia.FindById(dtoEnvio.AgenciaDestinoId.Value);
                    if (agenciaDestino == null) throw new AgenciaNoExisteException("La agencia de destino no existe.");

                    ((EnvioComun)envio).AgenciaDestino = agenciaDestino;
                    ((EnvioComun)envio).AgenciaDestinoId = agenciaDestino.Id;
                }

                envio.Cliente = cliente;
                envio.Empleado = empleado;

                envio.Validar();

                int idAgregado = _repositorioEnvio.Add(envio);

                Auditoria aud = new Auditoria(dtoEnvio.LogueadoId, "ALTA", "ENVIO", idAgregado.ToString(), JsonSerializer.Serialize(envio));
                _repositorioAuditoria.Auditar(aud);
            }
            catch (Exception e)
            {
                Auditoria aud = new Auditoria(dtoEnvio.LogueadoId, "ALTA", "ENVIO", null, e.Message);
                _repositorioAuditoria.Auditar(aud);

                throw e;
            }
        }
    }
}
