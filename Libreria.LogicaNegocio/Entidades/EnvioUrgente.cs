using Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions;
using Libreria.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class EnvioUrgente:Envio
    {
        public Direccion Direccion { get; set; }
        public bool? EntregaEficiente { get; set; }
        
        public EnvioUrgente(decimal peso, Usuario empleado, Usuario cliente, Direccion direccion) : base(peso, empleado, cliente)
        {
            Direccion = direccion;
            Validar();
        }

        public EnvioUrgente() : base()
        {
        }

        public override void Validar()
        {
            base.Validar();
            if (Direccion == null)
            {
                throw new SinDireccionException("La dirección no puede ser nula.");
            }
        }

        public void EvaluarEficienciaEntrega()
        {

            if (!FechaEntrega.HasValue)
            {
                throw new SinFechaDeEntregaException("No se puede evaluar la eficiencia de un envío sin fecha de entrega.");
            }

            TimeSpan tiempoTranscurrido = FechaEntrega.Value - FechaCreacion;
            EntregaEficiente = tiempoTranscurrido.TotalHours < 24;
            
        }

    }
}
