using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enumerados;
using Libreria.LogicaNegocio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.DTOs.Mappers
{
    public class MapperEnvio
    {

        public static Envio FromDTOAltaEnvioToEnvio(DTOAltaEnvio dto)
        {

            Envio envioNuevo;

            if (dto.TipoEnvio != null && dto.TipoEnvio.Equals("comun", StringComparison.OrdinalIgnoreCase))
            {

                envioNuevo = new EnvioComun();

                envioNuevo.ClienteId = dto.ClienteId;
                ((EnvioComun)envioNuevo).AgenciaDestinoId = (int)dto.AgenciaDestinoId;
                envioNuevo.EmpleadoId = (int)dto.LogueadoId;
                envioNuevo.Estado = EstadoEnvio.EN_PROCESO;
                envioNuevo.FechaCreacion = DateTime.Now;
                envioNuevo.Peso = dto.Peso;
                envioNuevo.Seguimientos = new List<SeguimientoEnvio>();
                envioNuevo.NroTracking = envioNuevo.GenerarNroTracking(dto.ClienteId);

            }
            else if (dto.TipoEnvio != null && dto.TipoEnvio.Equals("urgente", StringComparison.OrdinalIgnoreCase))
            {
                Direccion direccion = new Direccion(dto.Calle, dto.NroPuerta ?? 0, dto.Departamento);
                direccion.Validar();

                envioNuevo = new EnvioUrgente();

                envioNuevo.ClienteId = dto.ClienteId;
                envioNuevo.EmpleadoId = (int)dto.LogueadoId;
                envioNuevo.Estado = EstadoEnvio.EN_PROCESO;
                envioNuevo.FechaCreacion = DateTime.Now;
                envioNuevo.Peso = dto.Peso;
                envioNuevo.Seguimientos = new List<SeguimientoEnvio>();
                envioNuevo.NroTracking = envioNuevo.GenerarNroTracking(dto.ClienteId);
                ((EnvioUrgente)envioNuevo).Direccion = direccion;

            }
            else
            {
                throw new TipoEnvioNoValidoException("Tipo de envío no válido");
            }

            return envioNuevo;
        }

        public static List<DTOEnvio> FromListEnvioToListDTOEnvio(List<Envio> envios)
        {
            List<DTOEnvio> listaDTO = new List<DTOEnvio>();
            foreach (Envio envio in envios)
            {
                DTOEnvio dto = new DTOEnvio
                {
                    Id = envio.Id,
                    NroTracking = envio.NroTracking,
                    EmpleadoId = envio.EmpleadoId,
                    Empleado = envio.Empleado.Email,
                    ClienteId = envio.ClienteId,
                    Cliente = envio.Cliente.Email,
                    Peso = envio.Peso,
                    Estado = envio.Estado.ToString(),
                    FechaCreacion = envio.FechaCreacion,
                    FechaEntrega = envio.FechaEntrega,
                    TipoEnvio = envio is EnvioComun ? "comun" : envio is EnvioUrgente ? "urgente" : "desconocido"
                };

                // Si es un EnvioUrgente, mapea la dirección y si tuvo entrega eficiente
                if (envio is EnvioUrgente envioUrgente)
                {
                    dto.Calle = envioUrgente.Direccion?.Calle;
                    dto.NroPuerta = envioUrgente.Direccion?.NroPuerta;
                    dto.Departamento = envioUrgente.Direccion?.Departamento;
                    dto.EntregaEficiente = envioUrgente.EntregaEficiente;
                }

                if (envio is EnvioComun envioComun)
                {
                    dto.AgenciaDestino = envioComun.AgenciaDestino.Nombre;
                    dto.AgenciaDestinoId = envioComun.AgenciaDestinoId;
                }

                listaDTO.Add(dto);
            }
            return listaDTO;
        }

        public static DTOEnvio FromEnvioToDTOEnvio(Envio envio)
        {
            DTOEnvio dto = new DTOEnvio
            {
                Id = envio.Id,
                NroTracking = envio.NroTracking,
                EmpleadoId = envio.EmpleadoId,
                Empleado = envio.Empleado.Email,
                ClienteId = envio.ClienteId,
                Cliente = envio.Cliente.Email,
                Peso = envio.Peso,
                Estado = envio.Estado.ToString(),
                FechaCreacion = envio.FechaCreacion,
                FechaEntrega = envio.FechaEntrega,
                TipoEnvio = envio is EnvioComun ? "comun" : envio is EnvioUrgente ? "urgente" : "desconocido"
            };

            if (envio is EnvioUrgente envioUrgente)
            {
                dto.Calle = envioUrgente.Direccion?.Calle;
                dto.NroPuerta = envioUrgente.Direccion?.NroPuerta;
                dto.Departamento = envioUrgente.Direccion?.Departamento;
                dto.EntregaEficiente = envioUrgente.EntregaEficiente;
            }

            if (envio is EnvioComun envioComun)
            {
                dto.AgenciaDestino = envioComun.AgenciaDestino.Nombre;
                dto.AgenciaDestinoId = envioComun.AgenciaDestinoId;
            }
            return dto;

        }
    }
}
