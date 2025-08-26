using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enumerados;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Libreria.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private readonly ApplicationDbContext _context;

        public RepositorioEnvio(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Envio nuevo)
        {
            _context.Envios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public Envio FindById(int id)
        {

            return _context.Envios
            .Include(e => e.Cliente)
            .Include(e => e.Empleado)
            .Include(e => (e as EnvioComun).AgenciaDestino)
            .Include(e => e.Seguimientos)
            .FirstOrDefault(e => e.Id == id);

        }

        public void Remove(int id)
        {
            Envio envio = _context.Envios.Find(id);
            if (envio != null)
            {
                _context.Envios.Remove(envio);
                _context.SaveChanges();
            }
        }

        public List<Envio> FindAll()
        {
            return _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Empleado)
                .Include(e => e.Seguimientos)
                .Where(e =>
                    (e is EnvioUrgente &&
                     (((EnvioUrgente)e).Direccion == null ||
                      (!string.IsNullOrEmpty(((EnvioUrgente)e).Direccion.Calle) &&
                       ((EnvioUrgente)e).Direccion.NroPuerta > 0 &&
                       !string.IsNullOrEmpty(((EnvioUrgente)e).Direccion.Departamento)))) ||
                    (e is EnvioComun &&
                     (((EnvioComun)e).AgenciaDestino == null ||
                      ((EnvioComun)e).AgenciaDestinoId > 0)))
                .Include("AgenciaDestino")
                .ToList();
        }

        public void Update(Envio obj)
        {
            _context.Envios.Update(obj);
            _context.SaveChanges();
        }

        public bool ExisteEnvio(int id)
        {
            return _context.Envios.Any(u => u.Id == id);

        }

        public List<Envio> FindEnviosEnProceso()
        {
            return _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Empleado)
                .Include(e => e.Seguimientos)
                .Where(e =>
                    e.Estado == EstadoEnvio.EN_PROCESO &&
                    (
                        (e is EnvioUrgente &&
                         (((EnvioUrgente)e).Direccion == null ||
                          (!string.IsNullOrEmpty(((EnvioUrgente)e).Direccion.Calle) &&
                           ((EnvioUrgente)e).Direccion.NroPuerta > 0 &&
                           !string.IsNullOrEmpty(((EnvioUrgente)e).Direccion.Departamento))))
                        ||
                        (e is EnvioComun &&
                         (((EnvioComun)e).AgenciaDestino == null ||
                          ((EnvioComun)e).AgenciaDestinoId > 0))
                    )
                )
                .Include("AgenciaDestino")
                .ToList();
        }

        public void EliminarEnvios(Usuario u)
        {
            List<Envio> enviosAEliminar = _context.Envios.Where(e => e.ClienteId == u.Id).ToList();
            if (enviosAEliminar.Count == 0) return;

            _context.Envios.RemoveRange(enviosAEliminar);
            _context.SaveChanges();
        }

        public Envio FindByNroTracking(string nro)
        {
            return _context.Envios
                .Include(e => e.Cliente)
                .Include(e => e.Empleado)
                .Include(e => (e as EnvioComun).AgenciaDestino)
                .Include(e => e.Seguimientos)
                .FirstOrDefault(e => e.NroTracking == nro);
        }
    }
}