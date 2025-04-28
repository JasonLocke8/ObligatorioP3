using Libreria.LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public abstract class Envio
    {
        public int Id { get; set; }
        public int NroTracking { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public Usuario Empleado { get; set; }
        public Usuario Cliente { get; set; }
        public decimal Peso { get; set; }
        public EstadoEnvio Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public List<SeguimientoEnvio> Seguimientos { get; set; }

        public Envio(int nroTracking, decimal peso, Usuario empleado, Usuario cliente)
        {
            NroTracking = nroTracking;
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = EstadoEnvio.EN_PROCESO;
            FechaCreacion = DateTime.Now;
            Seguimientos = new List<SeguimientoEnvio>();

        }

        public void Validar()
        {
            if (NroTracking <= 0)
            {
                throw new Exception("El número de tracking debe ser mayor a 0.");
            }
            if (Peso <= 0)
            {
                throw new Exception("El peso debe ser mayor a 0.");
            }
            if (Empleado == null)
            {
                throw new Exception("El empleado no puede ser nulo.");
            }
            if (Cliente == null)
            {
                throw new Exception("El cliente no puede ser nulo.");
            }
            if (Estado == EstadoEnvio.FINALIZADO && FechaEntrega == null)
            {
                throw new Exception("La fecha de entrega debe estar definida si el estado es FINALIZADO.");
            }
        }
    }
}
