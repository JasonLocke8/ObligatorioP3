using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorio<T> where T : class
    {
        int Add (T nuevo);
        T FindById (int id);
        void Remove(int id);
        List<T> FindAll ();
        void Update(T obj);
    }
}
