using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions
{
    public class SinAgenciaException : Exception
    {
        public SinAgenciaException(string message) : base(message)
        {
        }

    }
}
