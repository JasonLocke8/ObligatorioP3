using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaNegocio.CustomExceptions.AgenciaExceptions;
using Libreria.LogicaNegocio.CustomExceptions.SharedExceptions;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUAgencia
{
    public class CUEliminarAgencia : ICUEliminarAgencia
    {
        private IRepositorioAgencia _repositorioAgencia;
        public CUEliminarAgencia(IRepositorioAgencia repositorioAgencia)
        {
            _repositorioAgencia = repositorioAgencia;
        }
        public void EliminarAgencia(int id)
        {
            if (!_repositorioAgencia.ExisteAgencia(id))
            {
                throw new AgenciaNoExiste("La agencia no existe");
            }

            _repositorioAgencia.Remove(id);

            // Verificar si la agencia fue eliminada correctamente
            if (_repositorioAgencia.ExisteAgencia(id))
            {
                throw new NoEliminacion("No se pudo eliminar la agencia");
            }
        }
    }
}
