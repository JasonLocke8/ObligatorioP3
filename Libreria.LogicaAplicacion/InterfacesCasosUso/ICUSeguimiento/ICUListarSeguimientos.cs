using Libreria.DTOs.DTOs.DTOsSeguimientoEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCasosUso.ICUSeguimiento
{
    public interface ICUListarSeguimientos
    {

        DTOSeguimientoEnvio ListarSeguimientoPorId(int id);

    }
}
