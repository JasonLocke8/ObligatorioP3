using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsSeguimientoEnvio
{
    public class DTOSeguimientoEnvio
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Ubicacion { get; set; }
        public string Observaciones { get; set; }
        public DTOSeguimientoEnvio(int id, DateTime fecha, string ubicacion, string observaciones)
        {
            Id = id;
            Fecha = fecha;
            Ubicacion = ubicacion;
            Observaciones = observaciones;
        }
        public DTOSeguimientoEnvio()
        {
        }
    }
}
