using Libreria.DTOs.DTOs.DTOsEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios
{
    public interface ICUAltaEnvio
    {
        void AltaEnvio(DTOAltaEnvio dtoEnvio);

    }
}
