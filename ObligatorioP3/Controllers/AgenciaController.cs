using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Microsoft.AspNetCore.Mvc;

namespace ObligatorioP3.Controllers
{
    public class AgenciaController : Controller
    {

        private ICUAltaAgencia _cuAltaAgencia;
        private ICUListarAgencia _cuListarAgencia;
        private ICUEditarAgencia _cuEditarAgencia;
        private ICUEliminarAgencia _cuEliminarAgencia;

        public AgenciaController(ICUAltaAgencia cuAltaAgencia, ICUListarAgencia cuListarAgencia, ICUEliminarAgencia cuEliminarAgencia, ICUEditarAgencia cuEditarAgencia)
        {
            _cuAltaAgencia = cuAltaAgencia;
            _cuListarAgencia = cuListarAgencia;
            _cuEditarAgencia = cuEditarAgencia;
            _cuEliminarAgencia = cuEliminarAgencia;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MostrarAgencias()
        {
            try
            {
                List<DTOAgencia> listaAgencias = _cuListarAgencia.ListarAgencia();
                return View(listaAgencias);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult EliminarAgencia(int id)
        {
            try
            {
                _cuEliminarAgencia.EliminarAgencia(id);
                ViewBag.Mensaje = "Agencia eliminada correctamente";
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }
            return RedirectToAction("MostrarAgencias");
        }

        public IActionResult ModificarAgencia(int id)
        {
            try
            {
                DTOAgencia agencia = _cuListarAgencia.ListarAgenciaPorId(id);
                return View(agencia);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult ModificarAgencia(DTOAgencia dtoAgencia)
        {
            try
            {
                _cuEditarAgencia.EditarAgencia(dtoAgencia);
                ViewBag.Mensaje = "Agencia modificada correctamente";
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }
            return View();

        }

        public IActionResult AltaAgencia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AltaAgencia(DTOAgencia dtoAgencia)
        {

            try
            {
                _cuAltaAgencia.AltaAgencia(dtoAgencia);
                ViewBag.Mensaje = "Agencia creada correctamente";
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }


            return View();
        }
    }
}
