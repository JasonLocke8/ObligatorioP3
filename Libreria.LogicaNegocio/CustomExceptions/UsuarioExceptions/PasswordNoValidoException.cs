using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class PasswordNoValidoException : Exception
    {
        public PasswordNoValidoException(string message) : base(message)
        {
        }
    }
}
