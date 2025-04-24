using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.Mappers
{
    public class MapperUsuario
    {
        public static Usuario FromDTOUsuarioToUsuario(DTOUsuario dto)
        {
            Usuario usuario = new Usuario();
            usuario.Id = dto.Id;
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Email = dto.Email;
            usuario.Password = dto.Password;
            usuario.Rol = (RolUsuario)Enum.Parse(typeof(RolUsuario), dto.Rol, true);

            return usuario;
        }

        public static List<DTOUsuario> FromListUsuarioToListDTOUsuario(List<Usuario> lista)
        {
            List<DTOUsuario> listaDTO = new List<DTOUsuario>();
            foreach (Usuario u in lista)
            {
                DTOUsuario dto = new DTOUsuario(u.Id, u.Nombre, u.Apellido, u.Email, u.Rol.ToString());
                listaDTO.Add(dto);
            }
            return listaDTO;
        }

        public static DTOUsuario FromUsuarioToDTOUsuario(Usuario usuario)
        {
            return new DTOUsuario(usuario.Id, usuario.Nombre, usuario.Apellido, usuario.Email, usuario.Rol.ToString());
        }
    }
}
