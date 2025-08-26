using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUSeguimiento;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Libreria.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {

        private ICUListarEnvio _cuListarEnvio;

        public EnvioController(ICUListarEnvio cuListarEnvio)
        {
            _cuListarEnvio = cuListarEnvio;

        }

        [HttpGet("EnvioPorTracking")]
        public IActionResult GetEnvioPorTracking([FromQuery] string nroTracking)
        {
            try
            {

                DTOEnvio envio = _cuListarEnvio.ListarEnvioPorNroTracking(nroTracking);
                if (envio == null)
                {
                    return NotFound("No se encontró el envío con el número de seguimiento proporcionado.");
                }
                return Ok(envio);
            }
            catch (EnvioNoExisteException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Cliente")]
        [HttpGet("MisEnvios")]
        public IActionResult ListarMisEnvios()
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrEmpty(email))
                    return Unauthorized();

                // Filtrar los envíos por el email del cliente
                var todos = _cuListarEnvio.ListarTodosLosEnvios();
                var misEnvios = todos
                    .Where(e => e.Cliente == email)
                    .OrderByDescending(e => e.FechaCreacion)
                    .ToList();

                return Ok(misEnvios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [Authorize(Roles = "Cliente")]
        [HttpGet("EnviosPorFecha")]
        public IActionResult BuscarEnvios([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin, [FromQuery] string? estado = null)
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrEmpty(email))
                    return Unauthorized();

                List<DTOEnvio> todos = _cuListarEnvio.ListarTodosLosEnvios();

                // Filtrar por cliente, fechas y estado (si se especifica)
                var filtrados = todos
                    .Where(e => e.Cliente == email
                                && e.FechaCreacion.Date >= fechaInicio.Date
                                && e.FechaCreacion.Date <= fechaFin.Date
                                && (string.IsNullOrEmpty(estado) || e.Estado == estado))
                    .OrderBy(e => e.NroTracking)
                    .Select(e => new {
                        e.NroTracking,
                        e.Estado,
                        e.FechaCreacion,
                        e.FechaEntrega,
                        e.TipoEnvio
                    })
                    .ToList();

                return Ok(filtrados);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = "Cliente")]
        [HttpGet("EnviosPorComentario")]
        public IActionResult BuscarEnviosPorComentario([FromQuery] string palabra)
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrEmpty(email))
                    return Unauthorized();

                List<DTOEnvio> todos = _cuListarEnvio.ListarTodosLosEnvios();

                var filtrados = todos
                    .Where(e => e.Cliente == email &&
                                e.Seguimientos != null &&
                                e.Seguimientos.Any(s =>
                                    !string.IsNullOrEmpty(s.Comentario) &&
                                    s.Comentario.Contains(palabra, StringComparison.OrdinalIgnoreCase)))
                    .OrderByDescending(e => e.FechaCreacion)
                    .ToList();

                return Ok(filtrados);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
