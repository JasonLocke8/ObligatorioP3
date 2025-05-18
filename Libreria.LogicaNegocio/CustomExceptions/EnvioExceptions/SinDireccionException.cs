using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class SinDireccionException : Exception
    {
        public SinDireccionException(string message) : base(message)
        {
        }
    }
}
