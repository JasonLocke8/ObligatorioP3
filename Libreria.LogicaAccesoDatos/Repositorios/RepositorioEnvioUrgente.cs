using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvioUrgente : IRepositorioEnvioUrgente
    {
        private ApplicationDbContext _context;
        public RepositorioEnvioUrgente(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(EnvioUrgente nuevo)
        {
            _context.EnviosUrgentes.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }
        public List<EnvioUrgente> FindAll()
        {
            return _context.EnviosUrgentes.ToList();
        }
        public EnvioUrgente FindById(int id)
        {
            return _context.EnviosUrgentes.Find(id);
        }
        public void Remove(int id)
        {
            EnvioUrgente envio = _context.EnviosUrgentes.Find(id);
            if (envio != null)
            {
                _context.EnviosUrgentes.Remove(envio);
                _context.SaveChanges();
            }
        }
        public void Update(EnvioUrgente obj)
        {
            _context.EnviosUrgentes.Update(obj);
            _context.SaveChanges();
        }
    }
}
