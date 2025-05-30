﻿using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Enumerados;
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
        public bool Eliminado { get; set; }

        public Usuario()
        {
            Eliminado = false;
        }

        public Usuario(string nombre, string apellido, string email, string password)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Eliminado = false;
            Validar();

        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new NombreNoValidoException("El nombre no puede ser vacío");
            }
            if (String.IsNullOrEmpty(Apellido))
            {
                throw new ApellidoNoValidoException("El apellido no puede ser vacío");
            }
            if (String.IsNullOrEmpty(Email) || !Email.Contains('@'))
            {
                throw new EmailNoValidoException("El email no contiene @ o está vacío");
            }
            if (String.IsNullOrEmpty(Password))
            {
                throw new PasswordNoValidoException("La contraseña no puede ser vacío");
            }
            if ((int)Rol < 0 || (int)Rol > 2)
            {
                throw new RolNoValidoException("El rol no es válido");
            }

        }

    }
}
