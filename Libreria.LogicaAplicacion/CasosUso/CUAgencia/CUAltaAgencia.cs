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
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUAgencia
{
    public class CUAltaAgencia : ICUAltaAgencia
    {
        private IRepositorioAgencia _repositorioAgencia;

        public CUAltaAgencia(IRepositorioAgencia repositorioAgencia)
        {
            _repositorioAgencia = repositorioAgencia;
        }

        public void AltaAgencia(DTOAgencia dtoAgencia)
        {
            try
            {
                if (_repositorioAgencia.ExisteAgenciaNombre(dtoAgencia.Nombre))
                {
                    throw new AgenciaExisteException("La agencia ya existe.");
                }

                Agencia nueva = MapperAgencia.FromDTOAgenciaToAgencia(dtoAgencia);
                nueva.Validar();
                _repositorioAgencia.Add(nueva);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}