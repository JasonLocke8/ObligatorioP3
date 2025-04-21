using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.DireccionExceptions
{
    public class NroPuertaNoValidoException:Exception
    {
        public NroPuertaNoValidoException(string message) : base(message)
        {
        }
    }
}
