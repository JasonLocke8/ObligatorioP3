using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.SeguimientoExceptions
{
    public class SeguimientoVacioException : Exception
    {
        public SeguimientoVacioException(string message) : base(message)
        {
        }

    }
}
