using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    internal class NoLogeadoException : Exception
    {
        public NoLogeadoException(string message) : base(message)
        {
        }

    }
}
