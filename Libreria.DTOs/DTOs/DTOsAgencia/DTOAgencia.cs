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
        public string Calle { get; set; }
        public int NroPuerta { get; set; }
        public string Departamento { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DTOAgencia(int id, string nombre, string calle, int nroPuerta, string departamento, double latitud, double longitud)
        {
            Id = id;
            Nombre = nombre;
            Calle = calle;
            NroPuerta = nroPuerta;
            Departamento = departamento;
            Latitud = latitud;
            Longitud = longitud;
        }
        public DTOAgencia()
        {
        }
    }
}
