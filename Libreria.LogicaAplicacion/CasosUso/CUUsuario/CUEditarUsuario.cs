using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enumerados;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUEditarUsuario : ICUEditarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        private IRepositorioAuditoria _repositorioAuditoria;

        public CUEditarUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public void EditarUsuario(DTOUsuario dtoUsuario)
        {
            try
            {

                // Verificar si el usuario existe
                if (!_repositorioUsuario.ExisteUsuario(dtoUsuario.Id))
                {
                    throw new UsuarioNoExisteException("El usuario no existe.");
                }

                // Traigo el usuario
                Usuario usuarioExistente = _repositorioUsuario.FindById(dtoUsuario.Id);

                usuarioExistente.Nombre = dtoUsuario.Nombre;
                usuarioExistente.Apellido = dtoUsuario.Apellido;
                usuarioExistente.Email = dtoUsuario.Email;

                try
                {
                    usuarioExistente.Rol = Enum.Parse<RolUsuario>(dtoUsuario.Rol);
                }
                catch (ArgumentException)
                {
                    throw new RolNoValidoException("No existe el rol");
                }


                // Agrego la Password
                if (dtoUsuario.Password != null)
                {
                    usuarioExistente.Password = BCrypt.Net.BCrypt.HashPassword(dtoUsuario.Password);
                }

                usuarioExistente.Validar();

                _repositorioUsuario.Update(usuarioExistente);

                Auditoria aud = new Auditoria(dtoUsuario.LogueadoId, "EDIT", "USUARIO", dtoUsuario.Id.ToString(), JsonSerializer.Serialize(usuarioExistente));
                _repositorioAuditoria.Auditar(aud);

            }
            catch (Exception e)
            {
                Auditoria aud = new Auditoria(dtoUsuario.LogueadoId, "EDIT", "USUARIO", null, e.Message);
                _repositorioAuditoria.Auditar(aud);

                throw e;
            }
        }
    }
}
