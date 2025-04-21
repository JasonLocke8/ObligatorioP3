using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsUsuario
{
    public class DTOUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public int Rol { get; set; }
        public DTOUsuario(int id, string nombre, string apellido, string email, int rol)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Rol = rol;
        }
        public DTOUsuario()
        {
        }
    }
}
