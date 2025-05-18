using Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class EnvioComun:Envio
    {
        public int AgenciaDestinoId { get; set; }
        public Agencia AgenciaDestino { get; set; }        

        public EnvioComun(decimal peso, Usuario empleado, Usuario cliente, Agencia agenciaDestino) : base(peso, empleado, cliente)
        {
            AgenciaDestino = agenciaDestino;
            AgenciaDestinoId = agenciaDestino.Id;
            Validar();
        }

        public EnvioComun() : base()
        {
        }

        public override void Validar()
        {
            base.Validar();
            if (AgenciaDestino == null)
            {
                throw new SinAgenciaException("La agencia destino no puede ser nula.");
            }
            if (AgenciaDestinoId <= 0)
            {
                throw new SinAgenciaException("El ID de la agencia destino debe ser mayor a 0.");
            }
        }



    }
}
