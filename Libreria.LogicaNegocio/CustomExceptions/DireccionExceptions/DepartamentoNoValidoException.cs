using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.DireccionExceptions
{
    public class DepartamentoNoValidoException:Exception
    {
        public DepartamentoNoValidoException(string message) : base(message)
        {
        }
    }
}
