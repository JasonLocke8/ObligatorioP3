using Libreria.LogicaNegocio.CustomExceptions.DireccionExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.VO
{
    public record Direccion
    {
        public string Calle {  get; init; }
        public int NroPuerta { get; init; }
        public string Departamento { get; init; }

        public Direccion(string calle, int nroPuerta, string departamento)
        {
            Calle = calle;
            NroPuerta = nroPuerta;
            Departamento = departamento;
            Validar();
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Calle))
            {
                throw new CalleNoValidoException("La calle no puede ser vacío");
            }

            if (NroPuerta <= 0)
            {
                throw new NroPuertaNoValidoException("El número de puerta no puede ser menor o igual a cero");
            }

            if (String.IsNullOrEmpty(Departamento))
            {
                throw new DepartamentoNoValidoException("La ciudad no puede ser vacío");
            }

        }

    }
}
