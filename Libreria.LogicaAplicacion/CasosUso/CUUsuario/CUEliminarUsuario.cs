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
    public class CUEliminarUsuario : ICUEliminarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        private IRepositorioAuditoria _repositorioAuditoria;

        public CUEliminarUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioAuditoria = repositorioAuditoria;
        }
        public void EliminarUsuario(int id, int logueadoId)
        {
            try
            {

                if (!_repositorioUsuario.ExisteUsuario(id))
                {
                    throw new UsuarioNoExisteException("El usuario no existe");
                }

                Usuario usuario = _repositorioUsuario.FindById(id);

                usuario.Eliminado = true;
                _repositorioUsuario.Update(usuario);

                Auditoria aud = new Auditoria(logueadoId, "DELETE", "USUARIO", usuario.Id.ToString(), JsonSerializer.Serialize(usuario));
                _repositorioAuditoria.Auditar(aud);


            }
            catch (Exception e)
            {
                Auditoria aud = new Auditoria(logueadoId, "DELETE", "USUARIO", null, e.Message);
                _repositorioAuditoria.Auditar(aud);

                throw e;
            }


        }
    }
}
