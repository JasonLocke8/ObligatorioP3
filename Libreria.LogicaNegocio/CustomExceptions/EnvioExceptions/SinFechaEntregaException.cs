using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class SinFechaEntregaException : Exception
    {
        public SinFechaEntregaException(string message) : base(message)
        {
        }
    }
}
