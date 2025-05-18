using Libreria.DTOs.DTOs.DTOsSeguimientoEnvio;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.Mappers
{
    public class MapperSeguimientoEnvio
    {

        public static SeguimientoEnvio FromDTOSeguimientoToSeguimiento(DTOSeguimientoEnvio dto)
        {
            SeguimientoEnvio seguimiento = new SeguimientoEnvio();
            seguimiento.EnvioId = dto.EnvioId;
            seguimiento.Comentario = dto.Comentario;
            seguimiento.FechaComentario = DateTime.Now;
            return seguimiento;
        }

    }
}
