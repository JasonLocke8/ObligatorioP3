using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsEnvio
{
    public class DTOAltaEnvio
    {
        public string TipoEnvio { get; set; }
        public int ClienteId { get; set; }
        public decimal Peso { get; set; }
        public int? AgenciaDestinoId { get; set; }
        public string? Calle { get; set; }
        public int? NroPuerta { get; set; }
        public string? Departamento { get; set; }
        public int? LogueadoId { get; set; }

    }
}
