using Libreria.DTOs.DTOs.DTOsEnvio;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ObligatorioP3.Models
{
    public class AltaEnvioViewModel
    {
        public DTOAltaEnvio dtoAltaEnvio { get; set; }
        public List<SelectListItem> Clientes { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Agencias { get; set; } = new List<SelectListItem>();
    }
}
