using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions
{
    public class RolNoValido : Exception
    {
        public RolNoValido(string message) : base(message)
        {
        }

    }
}
