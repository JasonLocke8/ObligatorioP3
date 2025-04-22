using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario FindByEmail(string email);
        List<Usuario> FindByTipoUsuario(int rol);
        bool ExisteUsuario(string email);
    }
}
