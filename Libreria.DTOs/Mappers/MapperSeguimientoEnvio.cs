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

        public static List<DTOSeguimientoEnvio> FromListSeguimientoToListDTOSeguimiento(List<SeguimientoEnvio> lista)
        {
            List<DTOSeguimientoEnvio> resultado = new List<DTOSeguimientoEnvio>();

            if (lista == null) return resultado;

            foreach (SeguimientoEnvio seguimiento in lista)
            {
                DTOSeguimientoEnvio dto = new DTOSeguimientoEnvio
                {
                    Id = seguimiento.Id,
                    EnvioId = seguimiento.EnvioId,
                    Fecha = seguimiento.FechaComentario,
                    Comentario = seguimiento.Comentario,
                    IdEmpleado = seguimiento.ComentarioEmpleado != null ? seguimiento.ComentarioEmpleado.Id : 0
                };
                resultado.Add(dto);
            }

            return resultado;
        }

    }
}
