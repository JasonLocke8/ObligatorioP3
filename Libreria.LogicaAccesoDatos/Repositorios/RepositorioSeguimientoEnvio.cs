using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioSeguimientoEnvio : IRepositorioSeguimientoEnvio
    {
        private ApplicationDbContext _context;

        public RepositorioSeguimientoEnvio(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(SeguimientoEnvio nuevo)
        {
            _context.SeguimientosEnvios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<SeguimientoEnvio> FindAll()
        {
            return _context.SeguimientosEnvios.ToList();
        }

        public List<SeguimientoEnvio> FindByEnvioId(int id)
        {
            return _context.SeguimientosEnvios.Where(s => s.Envio.Id == id).ToList();

        }

        public SeguimientoEnvio FindById(int id)
        {
            return _context.SeguimientosEnvios.Find(id);
        }

        public void Remove(int id)
        {
            SeguimientoEnvio seguimiento = _context.SeguimientosEnvios.Find(id);
            if (seguimiento != null)
            {
                _context.SeguimientosEnvios.Remove(seguimiento);
                _context.SaveChanges();
            }
        }

        public void Update(SeguimientoEnvio obj)
        {
            _context.SeguimientosEnvios.Update(obj);
            _context.SaveChanges();
        }
    }
}
