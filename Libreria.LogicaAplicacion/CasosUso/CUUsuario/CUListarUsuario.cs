using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUListarUsuario : ICUListarUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;

        public CUListarUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public List<DTOUsuario> ListarUsuario()
        {
            List<Usuario> listaUsuarios = _repositorioUsuario.FindAll();

            List<DTOUsuario> listaDTO = MapperUsuario.FromListUsuarioToListDTOUsuario(listaUsuarios);

            return listaDTO;
        }
    }
}
