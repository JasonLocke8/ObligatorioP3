using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        private ApplicationDbContext _context;

        public RepositorioAuditoria(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Auditoria nuevo)
        {
            _context.Auditorias.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;

        }
        public Auditoria FindById(int id)
        {
            return _context.Auditorias.Find(id);
        }
        public List<Auditoria> FindAll()
        {
            return _context.Auditorias.ToList();
        }
        public void Remove(int id)
        {
            Auditoria auditoria = _context.Auditorias.Find(id);
            if (auditoria != null)
            {
                _context.Auditorias.Remove(auditoria);
                _context.SaveChanges();
            }
        }
        public void Update(Auditoria obj)
        {
            _context.Auditorias.Update(obj);
            _context.SaveChanges();
        }
    }
}
