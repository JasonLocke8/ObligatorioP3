using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioSeguimientoEnvio : IRepositorio<SeguimientoEnvio>
    {
        List<SeguimientoEnvio> FindByEnvioId(int id);
    }
}
