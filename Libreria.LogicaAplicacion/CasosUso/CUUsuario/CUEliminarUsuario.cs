using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.SharedExceptions;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUEliminarUsuario : ICUEliminarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CUEliminarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public void EliminarUsuario(int id)
        {

            if (!_repositorioUsuario.ExisteUsuario(id))
            {
                throw new UsuarioNoExiste("El usuario no existe");
            }

            _repositorioUsuario.Remove(id);

            // Verificar si el usuario fue eliminado correctamente
            if (_repositorioUsuario.ExisteUsuario(id))
            {
                throw new NoEliminacion("No se pudo eliminar el usuario");
            }

        }
    }
}
