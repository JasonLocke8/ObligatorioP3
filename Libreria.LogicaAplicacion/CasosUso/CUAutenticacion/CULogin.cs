using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAutenticacion;
using Libreria.LogicaNegocio.CustomExceptions.AutenticacionExceptions;
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
        private IRepositorioAuditoria _repositorioAuditoria;

        public CULogin(IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioAuditoria = repositorioAuditoria;
        }

        public DTOUsuario ValidarLogin(DTOUsuario dto)
        {
            try
            {
                Usuario usuario = _repositorioUsuario.FindByEmail(dto.Email);


                if (usuario != null && !usuario.Eliminado && Utilidades.Crypto.VerifyPasswordConBcrypt(dto.Password, usuario.Password))
                {
                    DTOUsuario ret = new DTOUsuario();
                    ret.Id = usuario.Id;
                    ret.Rol = usuario.Rol.ToString();
                    return ret;
                }
                else
                {
                    Auditoria aud = new Auditoria(usuario.Id , "USE", "LOGIN", usuario.Id.ToString(), "Intento de login");
                    _repositorioAuditoria.Auditar(aud);

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