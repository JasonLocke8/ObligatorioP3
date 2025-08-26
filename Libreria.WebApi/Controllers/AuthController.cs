using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAutenticacion;
using Libreria.LogicaNegocio.CustomExceptions.AutenticacionExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Libreria.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private ICULogin _CULogin;
        private readonly IConfiguration _configuration;

        public AuthController(ICULogin CULogin, IConfiguration configuration)
        {
            _CULogin = CULogin;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOLogin login)
        {
            try
            {
                DTOUsuario b = new DTOUsuario();
                b.Email = login.Email;
                b.Password = login.Password;
                DTOUsuario usuario = _CULogin.ValidarLogin(b);

                var clave = _configuration["JWT:SecretKey"] ?? "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK-89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
                var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));

                List<Claim> claims = [
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Rol)
                ];

                var credenciales = new SigningCredentials(claveCodificada, SecurityAlgorithms.HmacSha512Signature);
                var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddDays(1), signingCredentials: credenciales);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Token = jwt });
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [Authorize(Roles = "Cliente")]
        [HttpPost("cambiar-password")]
        public IActionResult CambiarPassword([FromBody] DTOCambioPassword cambio)
        {
            try
            {
                var email = User.FindFirstValue(ClaimTypes.Email);

                if (string.IsNullOrEmpty(email))
                    return Unauthorized();

                DTOUsuario usuario = new DTOUsuario();
                usuario.Email = email;
                usuario.Password = cambio.PasswordActual;

                DTOUsuario cambiazo;
                try
                {
                    cambiazo = _CULogin.ValidarLogin(usuario);
                }
                catch (MalasCredenciales)
                {
                    return BadRequest("La contraseña actual es incorrecta.");
                }
                catch
                {
                    return StatusCode(500, "Error interno al validar la contraseña.");
                }

                if (cambiazo == null)
                    return BadRequest("La contraseña actual es incorrecta.");

                bool actualizado = _CULogin.CambiarPassword(email, cambio.PasswordNueva);
                if (!actualizado)
                    return StatusCode(500, "No se pudo actualizar la contraseña.");

                return Ok("Contraseña actualizada correctamente.");
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }
    }
}