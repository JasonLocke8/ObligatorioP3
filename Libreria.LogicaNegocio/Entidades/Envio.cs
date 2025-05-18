using Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions;
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
        public string NroTracking { get; set; }
        public int EmpleadoId { get; set; }
        public int ClienteId { get; set; }
        public Usuario Empleado { get; set; }
        public Usuario Cliente { get; set; }
        public decimal Peso { get; set; }
        public EstadoEnvio Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public List<SeguimientoEnvio> Seguimientos { get; set; }

        public Envio(decimal peso, Usuario empleado, Usuario cliente)
        {
            FechaCreacion = DateTime.Now;
            Empleado = empleado;
            Cliente = cliente;
            EmpleadoId = empleado.Id;
            ClienteId = cliente.Id;
            Peso = peso;
            Estado = EstadoEnvio.EN_PROCESO;
            Seguimientos = new List<SeguimientoEnvio>();
            NroTracking = GenerarNroTracking(cliente.Id);

            Validar();

        }
        public Envio()
        {
            
        }

        public virtual void Validar()
        {
            if (Peso <= 0)
            {
                throw new SinPesoException("El peso debe ser mayor a 0.");
            }
            if (Empleado == null)
            {
                throw new SinEmpleadoException("El empleado no puede ser nulo.");
            }
            if (EmpleadoId <= 0)
            {
                throw new SinEmpleadoException("El ID del empleado debe ser mayor a 0.");
            }
            if (Cliente == null)
            {
                throw new SinClienteException("El cliente no puede ser nulo.");
            }
            if (ClienteId <= 0)
            {
                throw new SinClienteException("El ID del cliente debe ser mayor a 0.");
            }
            if (Estado == EstadoEnvio.FINALIZADO && FechaEntrega == null)
            {
                throw new SinFechaEntregaException("La fecha de entrega debe estar definida si el estado es FINALIZADO.");
            }
            
        }

        public virtual string GenerarNroTracking(int clienteId)
        {
            string fechaActual = DateTime.Now.ToString("yyyyMMddHHmmss");
            return $"UYU{clienteId}{fechaActual}";
        }

    }
}
