using Libreria.DTOs.DTOs.DTOsEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios
{
    public interface ICUListarEnvio
    {
        List<DTOEnvio> ListarEnvios();

        List<DTOEnvio> ListarTodosLosEnvios();

        DTOEnvio ListarEnvioPorId(int id);

        DTOEnvio ListarEnvioPorNroTracking(string nroTracking);

    }
}
