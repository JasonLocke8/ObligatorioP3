using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAutenticacion;
using Libreria.LogicaNegocio.CustomExceptions.AutenticacionExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public DTOUsuario ValidarLogin(DTOUsuario dto)
        {
            try
            {
                Usuario usuario = _repositorioUsuario.FindByEmail(dto.Email);


                if (usuario != null && Utilidades.Crypto.VerifyPasswordConBcrypt(dto.Password, usuario.Password))
                {
                    DTOUsuario ret = new DTOUsuario();
                    ret.Id = usuario.Id;
                    ret.Rol = usuario.Rol.ToString();
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