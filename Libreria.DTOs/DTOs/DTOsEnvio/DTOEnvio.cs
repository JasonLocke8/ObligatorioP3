using Libreria.DTOs.DTOs.DTOsSeguimientoEnvio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsEnvio
{
    public class DTOEnvio
    {

        public int Id { get; set; }
        public string NroTracking { get; set; }
        public int EmpleadoId { get; set; }
        public string Empleado { get; set; }
        public int ClienteId { get; set; }
        public string Cliente { get; set; }
        public decimal Peso { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public List<DTOSeguimientoEnvio> Seguimientos { get; set; }
        public int? AgenciaDestinoId { get; set; }
        public string? AgenciaDestino { get; set; }
        public string? Calle { get; set; }
        public int? NroPuerta { get; set; }
        public string? Departamento { get; set; }
        public bool? EntregaEficiente { get; set; }
        public string TipoEnvio { get; set; }

    }
}
