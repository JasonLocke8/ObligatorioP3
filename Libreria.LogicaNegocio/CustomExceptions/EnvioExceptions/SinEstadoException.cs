using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class SinEstadoException : Exception
    {
        public SinEstadoException(string message) : base(message)
        {
        }
    }
}
