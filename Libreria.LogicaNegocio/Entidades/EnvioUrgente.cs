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
        
        public EnvioUrgente(int nroTracking, decimal peso, Usuario empleado, Usuario cliente, Direccion direccion, bool entregaEficiente) : base(nroTracking, peso, empleado, cliente)
        {
            Direccion = direccion;
            EntregaEficiente = entregaEficiente;
        }

        public EnvioUrgente() : base(0, 0, null, null)
        {
        }

        public void EvaluarEficienciaEntrega()
        {

            if (!FechaEntrega.HasValue)
            {
                throw new SinFechaDeEntrega("No se puede evaluar la eficiencia de un envío sin fecha de entrega.");
            }

            TimeSpan tiempoTranscurrido = FechaEntrega.Value - FechaCreacion;
            EntregaEficiente = tiempoTranscurrido.TotalHours < 24;
            
        }

    }
}
