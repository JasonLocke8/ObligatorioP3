using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enumerados;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;
        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Usuario nuevo)
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }
        public Usuario FindById(int id)
        {
            return _context.Usuarios.Find(id);
        }
        public void Remove(int id)
        {
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }
        public List<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }
        public void Update(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
        }
        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);

        }
        public List<Usuario> FindByTipoUsuario(int rol)
        {
            // Convertir el entero a RolUsuario
            RolUsuario rolUsuario = (RolUsuario)rol;

            return _context.Usuarios.Where(u => u.Rol == rolUsuario).ToList();
        }
        public bool ExisteUsuario(int id)
        {
            return _context.Usuarios.Any(u => u.Id == id);
        }

        public bool ExisteUsuarioEmail(string email)
        {
            return _context.Usuarios.Any(u => u.Email == email);
        }
    }
}
