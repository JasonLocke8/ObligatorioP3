using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class EnvioComun:Envio
    {
        public Agencia AgenciaDestino { get; set; }        

        public EnvioComun(int nroTracking, decimal peso, Usuario empleado, Usuario cliente, Agencia agenciaDestino) : base(nroTracking, peso, empleado, cliente)
        {
            AgenciaDestino = agenciaDestino;
        }

        public EnvioComun() : base(0, 0, null, null)
        {
        }



    }
}
