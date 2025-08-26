using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.AutenticacionExceptions
{
    public class CampoVacioException : Exception
    {
        public CampoVacioException(string message) : base(message)
        {
        }

    }
}
