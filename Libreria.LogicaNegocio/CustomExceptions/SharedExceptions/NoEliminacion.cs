using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.SharedExceptions
{
    public class NoEliminacion : Exception
    {
        public NoEliminacion(string message) : base(message)
        {
        }

    }

}
