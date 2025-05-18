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
        public int EnvioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int IdEmpleado { get; set; }
        public DTOSeguimientoEnvio(int envioId, string comentario, int idEmpleado)
        {
            EnvioId = envioId;
            Fecha = DateTime.Now;
            Comentario = comentario;
            IdEmpleado = idEmpleado;
        }
        public DTOSeguimientoEnvio()
        {
        }
    }
}