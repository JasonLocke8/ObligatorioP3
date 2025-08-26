using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        List<Envio> FindAll();

        List<Envio> FindEnviosEnProceso();

        void EliminarEnvios(Usuario u);

        bool ExisteEnvio(int id);

        Envio FindByNroTracking(string nro);
    }

}
