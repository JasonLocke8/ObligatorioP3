using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Enumerados;
using Libreria.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RolUsuario Rol { get; set; }

        // Constructor
        public Usuario()
        {

        }

        public Usuario(string nombre, string apellido, string email, string password)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;

            if (String.IsNullOrEmpty(Nombre))
            {
                throw new NombreNoValidoException("El nombre no puede ser vacío");
            }
            if (String.IsNullOrEmpty(Apellido))
            {
                throw new ApellidoNoValidoException("El apellido no puede ser vacío");
            }
            if (String.IsNullOrEmpty(Email) || !email.Contains('@'))
            {
                throw new EmailNoValidoException("El email no contiene @ o está vacío");
            }
            if (String.IsNullOrEmpty(Password))
            {
                throw new PasswordNoValidoException("La contraseña no puede ser vacío");
            }
        }        

    }
}
