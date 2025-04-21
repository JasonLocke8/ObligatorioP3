using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.DTOs.DTOsAgencia
{
    public class DTOAgencia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Coordenadas { get; set; }
        public DTOAgencia(int id, string nombre, string direccion, string coordenadas)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Coordenadas = coordenadas;
        }
        public DTOAgencia()
        {
        }
    }
}
