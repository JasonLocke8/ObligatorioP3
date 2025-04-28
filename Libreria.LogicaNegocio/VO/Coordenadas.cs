using Libreria.LogicaNegocio.CustomExceptions.CoordenadasExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.VO
{
    [ComplexType]
    public record Coordenadas
    {
        public double Latitud { get; init; }
        public double Longitud { get; init; }
        public Coordenadas(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
            Validar();
        }

        public void Validar()
        {
            if (Latitud < -90 || Latitud > 90)
            {
                throw new CoordenadasNoValidoException("La latitud no puede ser menor a -90 o mayor a 90");
            }
            if (Longitud < -180 || Longitud > 180)
            {
                throw new CoordenadasNoValidoException("La longitud no puede ser menor a -180 o mayor a 180");
            }
        }
    }
}
