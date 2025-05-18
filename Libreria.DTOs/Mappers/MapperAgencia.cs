using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.Mappers
{
    public class MapperAgencia
    {
        public static Agencia FromDTOAgenciaToAgencia(DTOAgencia dto)
        {
            Agencia agencia = new Agencia();
            agencia.Id = dto.Id;
            agencia.Nombre = dto.Nombre;
            agencia.Direccion = new Direccion(dto.Calle, dto.NroPuerta, dto.Departamento);
            agencia.Direccion.Validar();
            agencia.Coordenadas = new Coordenadas(dto.Latitud, dto.Longitud);

            return agencia;
        }

        public static List<DTOAgencia> FromListAgenciaToListDTOAgencia(List<Agencia> lista)
        {
            List<DTOAgencia> listaDTO = new List<DTOAgencia>();
            foreach (Agencia a in lista)
            {
                DTOAgencia dto = new DTOAgencia(a.Id, a.Nombre, a.Direccion.Calle, a.Direccion.NroPuerta, a.Direccion.Departamento, a.Coordenadas.Latitud, a.Coordenadas.Longitud);
                listaDTO.Add(dto);
            }
            return listaDTO;
        }

        public static DTOAgencia FromAgenciaToDTOAgencia(Agencia a)
        {
            return new DTOAgencia(a.Id, a.Nombre, a.Direccion.Calle, a.Direccion.NroPuerta, a.Direccion.Departamento, a.Coordenadas.Latitud, a.Coordenadas.Longitud);
        }
    }
}
