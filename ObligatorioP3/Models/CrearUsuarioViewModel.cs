using Libreria.DTOs.DTOs.DTOsUsuario;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ObligatorioP3.Models
{
    public class CrearUsuarioViewModel
    {
        public DTOUsuario Usuario { get; set; }

        public List<SelectListItem> Roles { get; set; } = new List<SelectListItem>() {
         new SelectListItem{ Text ="Administrador", Value="Administrador" },
         new SelectListItem{ Text ="Funcionario", Value="Funcionario" },
         new SelectListItem{ Text ="Cliente", Value="Cliente" }

         };

    }
}
