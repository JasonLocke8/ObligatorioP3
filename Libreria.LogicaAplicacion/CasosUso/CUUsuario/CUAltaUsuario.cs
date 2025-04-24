using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUAltaUsuario : ICUAltaUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CUAltaUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void AltaUsuario(DTOUsuario dtoUsuario)
        {
            // Buscar si el usuario ya existe

            if (_repositorioUsuario.ExisteUsuarioEmail(dtoUsuario.Email))
            {
                throw new UsuarioExiste("El usuario ya existe.");
            }

            dtoUsuario.Password = BCrypt.Net.BCrypt.HashPassword(dtoUsuario.Password);
            Usuario nuevo = MapperUsuario.FromDTOUsuarioToUsuario(dtoUsuario);
            nuevo.Validar();
            _repositorioUsuario.Add(nuevo);
        }
    }
}