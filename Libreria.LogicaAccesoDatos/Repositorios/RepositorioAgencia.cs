using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private ApplicationDbContext _context;
        public RepositorioAgencia(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Agencia nuevo)
        {
            _context.Agencias.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Agencia> FindAll()
        {
            return _context.Agencias.ToList();
        }

        public Agencia FindById(int id)
        {
            return _context.Agencias.Find(id);
        }

        public List<Agencia> FindByNombre(string nombre)
        {

            return _context.Agencias.Where(a => a.Nombre.Contains(nombre)).ToList();
            
        }

        public void Remove(int id)
        {
            Agencia agencia = _context.Agencias.Find(id);
            
            if (agencia != null)
            {
                _context.Agencias.Remove(agencia);
                _context.SaveChanges();
            }
            
        }

        public void Update(Agencia obj)
        {
            _context.Agencias.Update(obj);
            _context.SaveChanges();
        }
    }
}
