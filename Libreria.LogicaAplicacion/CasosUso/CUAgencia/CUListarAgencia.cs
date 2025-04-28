using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUAgencia
{
    public class CUListarAgencia : ICUListarAgencia
    {
        private readonly IRepositorioAgencia _repositorioAgencia;
        public CUListarAgencia(IRepositorioAgencia repositorioAgencia)
        {
            _repositorioAgencia = repositorioAgencia;
        }

        public List<DTOAgencia> ListarAgencia()
        {
            List<Agencia> listaAgencias = _repositorioAgencia.FindAll();

            List<DTOAgencia> listaDTO = MapperAgencia.FromListAgenciaToListDTOAgencia(listaAgencias);

            return listaDTO;
        }

        public DTOAgencia ListarAgenciaPorId(int id)
        {
            Agencia agencia = _repositorioAgencia.FindById(id);
            if (agencia == null)
            {
                throw new AgenciaNoExiste("Agencia no encontrada");
            }
            else
            {
                DTOAgencia dtoAgencia = MapperAgencia.FromAgenciaToDTOAgencia(agencia);
                return dtoAgencia;
            }
        }
    }
}
