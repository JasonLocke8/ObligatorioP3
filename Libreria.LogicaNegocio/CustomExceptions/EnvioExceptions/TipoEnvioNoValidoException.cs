using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions
{
    public class TipoEnvioNoValidoException : Exception
    {
        public TipoEnvioNoValidoException(string message) : base(message)
        {
        }

    }
}
