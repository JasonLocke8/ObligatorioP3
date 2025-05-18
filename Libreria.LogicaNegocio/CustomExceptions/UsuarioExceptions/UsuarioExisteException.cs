using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class UsuarioExisteException : Exception
    {
        public UsuarioExisteException(string message) : base(message)
        {
        }
    }
}

