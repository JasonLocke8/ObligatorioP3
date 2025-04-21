using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioAgencia : IRepositorio<Agencia>
    {

        List<Agencia> FindByNombre(string nombre);

    }
}
