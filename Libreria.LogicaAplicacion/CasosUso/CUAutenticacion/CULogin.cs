using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAutenticacion;
using Libreria.LogicaNegocio.CustomExceptions.AutenticacionExceptions;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUAutenticacion
{
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CULogin(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public bool CambiarPassword(string email, string nuevaPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nuevaPassword))
                {
                    throw new CampoVacioException("Campos vacios.");
                }
                Usuario usuario = _repositorioUsuario.FindByEmail(email);
                if (usuario == null || usuario.Eliminado)
                {
                    throw new UsuarioNoExisteException("Usuario no encontrado.");
                }
                usuario.Password = BCrypt.Net.BCrypt.HashPassword(nuevaPassword);
                _repositorioUsuario.Update(usuario);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public DTOUsuario ValidarLogin(DTOUsuario dto)
        {
            try
            {
                if (dto.Password == null || dto.Email == null)
                {
                    throw new CampoVacioException("Campos vacios.");
                }

                Usuario usuario = _repositorioUsuario.FindByEmail(dto.Email);


                if (usuario != null && !usuario.Eliminado && Utilidades.Crypto.VerifyPasswordConBcrypt(dto.Password, usuario.Password))
                {
                    DTOUsuario ret = new DTOUsuario();
                    ret.Id = usuario.Id;
                    ret.Rol = usuario.Rol.ToString();
                    ret.Email = usuario.Email;
                    return ret;
                }
                else
                {
                    throw new MalasCredenciales("Error de credenciales.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}