using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if (_repositorioAgencia.ExisteAgenciaNombre(dtoAgencia.Nombre))
            {
                throw new AgenciaExiste("La agencia ya existe.");
            }

            Agencia nueva = MapperAgencia.FromDTOAgenciaToAgencia(dtoAgencia);
            nueva.Validar();
            _repositorioAgencia.Add(nueva);
        }
    }
}