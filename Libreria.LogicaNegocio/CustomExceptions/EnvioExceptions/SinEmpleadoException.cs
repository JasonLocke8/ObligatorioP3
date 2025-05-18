using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    internal class SinEmpleadoException : Exception
    {
        public SinEmpleadoException(string message) : base(message)
        {
        }

    }
}
