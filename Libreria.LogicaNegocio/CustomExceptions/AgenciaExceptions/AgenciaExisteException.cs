using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions
{
    public class AgenciaExisteException : Exception
    {
        public AgenciaExisteException(string message) : base(message)
        {
        }
    }
}
