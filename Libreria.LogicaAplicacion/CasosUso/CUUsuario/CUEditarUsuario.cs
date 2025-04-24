using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enumerados;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUEditarUsuario : ICUEditarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CUEditarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void EditarUsuario(DTOUsuario dtoUsuario)
        {
            // Verificar si el usuario existe
            if (!_repositorioUsuario.ExisteUsuario(dtoUsuario.Id))
            {
                throw new UsuarioNoExiste("El usuario no existe.");
            }

            // Traigo el usuario
            Usuario usuarioExistente = _repositorioUsuario.FindById(dtoUsuario.Id);

            usuarioExistente.Nombre = dtoUsuario.Nombre;
            usuarioExistente.Apellido = dtoUsuario.Apellido;
            usuarioExistente.Email = dtoUsuario.Email;
            usuarioExistente.Rol = Enum.Parse<RolUsuario>(dtoUsuario.Rol);


            // Agrego la Password
            if (dtoUsuario.Password != null)
            {
                usuarioExistente.Password = BCrypt.Net.BCrypt.HashPassword(dtoUsuario.Password);
            }

            usuarioExistente.Validar();

            _repositorioUsuario.Update(usuarioExistente);

        }
    }
}
