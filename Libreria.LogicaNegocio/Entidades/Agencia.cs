using Libreria.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Agencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Direccion Direccion { get; set; }
        public Coordenadas Coordenadas { get; set; }

        public Agencia(string nombre, Direccion direccion, Coordenadas coordenadas)
        {
            Nombre = nombre;
            Direccion = direccion;
            Coordenadas = coordenadas;

            direccion.Validar();
            coordenadas.Validar();

        }

        public Agencia()
        {

        }

    }
}
