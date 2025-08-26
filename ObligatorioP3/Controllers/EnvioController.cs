using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUSeguimiento;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObligatorioP3.Filters;
using ObligatorioP3.Models;

namespace ObligatorioP3.Controllers
{
    public class EnvioController : Controller
    {

        private ICUAltaEnvio _cuAltaEnvio;
        private ICUListarEnvio _cuListarEnvio;
        private ICUFinalizarEnvio _cuFinalizarEnvio;
        private ICUListarUsuario _cuListarUsuario;
        private ICUListarAgencia _cuListarAgencia;
        private ICUAgregarSeguimiento _cuAgregarSeguimiento;


        public EnvioController(ICUAltaEnvio cuAltaEnvio, ICUListarEnvio cuListarEnvio, ICUFinalizarEnvio cuFinalizarEnvio, ICUListarUsuario cuListarUsuario, ICUListarAgencia cuListarAgencia, ICUAgregarSeguimiento cuAgregarSeguimiento)
        {
            _cuAltaEnvio = cuAltaEnvio;
            _cuListarEnvio = cuListarEnvio;
            _cuFinalizarEnvio = cuFinalizarEnvio;
            _cuListarUsuario = cuListarUsuario;
            _cuListarAgencia = cuListarAgencia;
            _cuAgregarSeguimiento = cuAgregarSeguimiento;
        }

        [FuncionarioAuthorize]
        public IActionResult Index()
        {
            try
            {
                List<DTOEnvio> envios = _cuListarEnvio.ListarEnvios();
                return View(envios);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [FuncionarioAuthorize]
        public IActionResult AltaEnvio()
        {
            List<DTOUsuario> clientes = _cuListarUsuario.ListarUsuario();
            List<DTOAgencia> agencias = _cuListarAgencia.ListarAgencia();

            AltaEnvioViewModel viewModel = new AltaEnvioViewModel();

            foreach (DTOUsuario cli in clientes)
            {
                SelectListItem sitem = new SelectListItem();
                sitem.Text = cli.Email;
                sitem.Value = cli.Id.ToString();
                viewModel.Clientes.Add(sitem);
            }

            foreach (DTOAgencia ag in agencias)
            {
                SelectListItem sitem = new SelectListItem();
                sitem.Text = ag.Nombre;
                sitem.Value = ag.Id.ToString();
                viewModel.Agencias.Add(sitem);
            }

            return View(viewModel);
        }

        [HttpPost]
        [FuncionarioAuthorize]
        public IActionResult AltaEnvio(AltaEnvioViewModel viewModel)
        {
            try
            {
                viewModel.dtoAltaEnvio.LogueadoId = HttpContext.Session.GetInt32("LogueadoID");

                _cuAltaEnvio.AltaEnvio(viewModel.dtoAltaEnvio);
                TempData["Mensaje"] = "Envío creado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [FuncionarioAuthorize]
        public IActionResult FinalizarEnvio(int id)
        {
            try
            {
                int logueadoId = (int)HttpContext.Session.GetInt32("LogueadoID");
                _cuFinalizarEnvio.FinalizarEnvio(id, logueadoId);
                TempData["Mensaje"] = "Envio finalizado correctamente.";
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
            }
            return RedirectToAction("Index");
        }

        [FuncionarioAuthorize]
        public IActionResult NuevoSeguimiento(int id)
        {
            try
            {

                NuevoSeguimientoViewModel viewModel = new NuevoSeguimientoViewModel();

                viewModel.Envio = _cuListarEnvio.ListarEnvioPorId(id);

                return View(viewModel);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [HttpPost]
        [FuncionarioAuthorize]
        public IActionResult NuevoSeguimiento(NuevoSeguimientoViewModel viewModel)
        {
            try
            {

                viewModel.Seguimiento.IdEmpleado = (int)HttpContext.Session.GetInt32("LogueadoID");
                viewModel.Seguimiento.EnvioId = viewModel.Envio.Id;

                _cuAgregarSeguimiento.AgregarSeguimiento(viewModel.Seguimiento);

                TempData["Mensaje"] = "Seguimiento creado correctamente";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
