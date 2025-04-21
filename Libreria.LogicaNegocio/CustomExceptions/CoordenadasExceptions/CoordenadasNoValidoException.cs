using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.CoordenadasExceptions
{
    public class CoordenadasNoValidoException:Exception
    {
        public CoordenadasNoValidoException(string message) : base(message)
        {

        }
    }
}
