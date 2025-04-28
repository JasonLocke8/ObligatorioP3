using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Libreria.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUAgencia
{
    public class CUEditarAgencia : ICUEditarAgencia
    {
        private IRepositorioAgencia _repositorioAgencia;

        public CUEditarAgencia(IRepositorioAgencia repositorioAgencia)
        {
            _repositorioAgencia = repositorioAgencia;
        }

        public void EditarAgencia(DTOAgencia dtoAgencia)
        {
            // Verificar si la agencia existe
            if (!_repositorioAgencia.ExisteAgencia(dtoAgencia.Id))
            {
                throw new AgenciaNoExiste("La agencia no existe.");
            }

            // Traigo la agencia
            Agencia agenciaExistente = _repositorioAgencia.FindById(dtoAgencia.Id);

            agenciaExistente.Nombre = dtoAgencia.Nombre;
            agenciaExistente.Direccion = new Direccion(
                dtoAgencia.Calle,
                dtoAgencia.NroPuerta,
                dtoAgencia.Departamento
                );
            agenciaExistente.Coordenadas = new Coordenadas(
                dtoAgencia.Latitud,
                dtoAgencia.Longitud
                );

            agenciaExistente.Validar();

            _repositorioAgencia.Update(agenciaExistente);
        }
    }
}
