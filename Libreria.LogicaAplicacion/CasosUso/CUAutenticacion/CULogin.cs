using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAutenticacion;
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

        public DTOUsuario Login(DTOUsuario dto)
        {

            Usuario usuario = _repositorioUsuario.FindByEmail(dto.Email);


            if (usuario == null || !Utilidades.Crypto.VerifyPasswordConBcrypt(dto.Password, usuario.Password))
            {
                throw new Exception("El email o la contraseña son incorrectos");
            }
            else
            {
                return new DTOUsuario(usuario.Id, usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Rol.ToString());
            }

        }
    }
}
