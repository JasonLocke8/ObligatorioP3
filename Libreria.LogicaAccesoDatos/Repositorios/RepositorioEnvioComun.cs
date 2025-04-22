using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvioComun : IRepositorioEnvioComun
    {

        private ApplicationDbContext _context;

        public RepositorioEnvioComun(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(EnvioComun nuevo)
        {
            _context.EnviosComunes.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;

        }
        public EnvioComun FindById(int id)
        {
            return _context.EnviosComunes.Find(id);

        }
        public void Remove(int id)
        {
            EnvioComun envio = _context.EnviosComunes.Find(id);
            if (envio != null)
            {
                _context.EnviosComunes.Remove(envio);
                _context.SaveChanges();
            }

        }
        public List<EnvioComun> FindAll()
        {
            return _context.EnviosComunes.ToList();
        }
        public void Update(EnvioComun obj)
        {

            _context.EnviosComunes.Update(obj);
            _context.SaveChanges();

        }
    }
}
