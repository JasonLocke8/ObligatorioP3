using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Microsoft.AspNetCore.Mvc;
using ObligatorioP3.Filters;

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

        [AdminAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [AdminAuthorize]
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

        [AdminAuthorize]
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

        [AdminAuthorize]
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

        [AdminAuthorize]
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

        [AdminAuthorize]
        public IActionResult AltaAgencia()
        {
            return View();
        }

        [AdminAuthorize]
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
