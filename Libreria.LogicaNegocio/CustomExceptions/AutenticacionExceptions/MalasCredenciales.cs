using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.AutenticacionExceptions
{
    public class MalasCredenciales : Exception
    {
        public MalasCredenciales(string message) : base(message)
        {
        }

    }
}
