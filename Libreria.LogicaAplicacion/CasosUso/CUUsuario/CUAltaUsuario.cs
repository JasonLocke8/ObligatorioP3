using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        private IRepositorioAuditoria _repositorioAuditoria;

        public CUAltaUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void AltaUsuario(DTOUsuario dtoUsuario)
        {

            try
            {
                if (_repositorioUsuario.ExisteUsuarioEmail(dtoUsuario.Email))
                {
                    throw new UsuarioExisteException("El usuario ya existe.");
                }

                dtoUsuario.Password = BCrypt.Net.BCrypt.HashPassword(dtoUsuario.Password);
                Usuario nuevo = MapperUsuario.FromDTOUsuarioToUsuario(dtoUsuario);
                nuevo.Validar();

                int idNuevo = _repositorioUsuario.Add(nuevo);

                Auditoria aud = new Auditoria(dtoUsuario.LogueadoId, "ALTA", "USUARIO", idNuevo.ToString(), JsonSerializer.Serialize(nuevo));
                _repositorioAuditoria.Auditar(aud);

            }
            catch (Exception e)
            {
                Auditoria aud = new Auditoria(dtoUsuario.LogueadoId, "ALTA", "USUARIO", null, e.Message);
                _repositorioAuditoria.Auditar(aud);

                throw e;
            }
        }
            
    }
}