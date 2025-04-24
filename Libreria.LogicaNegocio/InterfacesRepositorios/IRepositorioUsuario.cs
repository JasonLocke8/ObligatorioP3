using Libreria.LogicaNegocio.Entidades;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario FindByEmail(string email);
        List<Usuario> FindByTipoUsuario(int rol);
        bool ExisteUsuario(int id);
        bool ExisteUsuarioEmail(string email);
    }
}
