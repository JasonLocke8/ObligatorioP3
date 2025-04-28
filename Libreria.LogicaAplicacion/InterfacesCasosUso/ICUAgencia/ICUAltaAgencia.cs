using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia
{
    public interface ICUAltaAgencia
    {
        void AltaAgencia(DTOAgencia dtoAgencia);

    }
}
