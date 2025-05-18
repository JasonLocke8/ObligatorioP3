using Libreria.DTOs.DTOs.DTOsAgencia;
using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAutenticacion;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUSeguimiento;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ObligatorioP3.Filters;
using ObligatorioP3.Models;

namespace ObligatorioP3.Controllers
{
    public class UsuarioController : Controller
    {

        private ICUAltaUsuario _cuAltaUsuario;
        private ICUListarUsuario _cuListarUsuario;
        private ICUEditarUsuario _cuEditarUsuario;
        private ICUEliminarUsuario _cuEliminarUsuario;
        private ICUAltaEnvio _cuAltaEnvio;
        private ICUListarEnvio _cuListarEnvio;
        private ICULogin _cuLogin;
        private ICUListarAgencia _cuListarAgencia;
        private ICUFinalizarEnvio _cuFinalizarEnvio;
        private ICUAgregarSeguimiento _cuAgregarSeguimiento;

        public UsuarioController(ICUAgregarSeguimiento cuAgregarSeguimiento, ICUFinalizarEnvio cuFinalizarEnvio, ICUListarAgencia cuListarAgencia, ICUListarEnvio cuListarEnvio, ICULogin cuLogin, ICUAltaEnvio cuAltaEnvio, ICUAltaUsuario cuAltaUsuario, ICUListarUsuario cuListarUsuario, ICUEditarUsuario cuEditarUsuario, ICUEliminarUsuario cuEliminarUsuario)
        {
            _cuAltaUsuario = cuAltaUsuario;
            _cuListarUsuario = cuListarUsuario;
            _cuEditarUsuario = cuEditarUsuario;
            _cuEliminarUsuario = cuEliminarUsuario;
            _cuLogin = cuLogin;
            _cuAltaEnvio = cuAltaEnvio;
            _cuListarEnvio = cuListarEnvio;
            _cuListarAgencia = cuListarAgencia;
            _cuFinalizarEnvio = cuFinalizarEnvio;
            _cuAgregarSeguimiento = cuAgregarSeguimiento;

        }

        [FuncionarioAuthorize]
        public IActionResult Index()
        {
            return View();
        }

        [AdminAuthorize]
        public IActionResult AltaUsuario()
        {
            try
            {

                CrearUsuarioViewModel viewModel = new CrearUsuarioViewModel();

                return View(viewModel);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [AdminAuthorize]
        [HttpPost]
        public IActionResult AltaUsuario(CrearUsuarioViewModel viewModel)
        {

            try
            {
                viewModel.Usuario.LogueadoId = (int)HttpContext.Session.GetInt32("LogueadoID");

                _cuAltaUsuario.AltaUsuario(viewModel.Usuario);

                TempData["Mensaje"] = "Usuario creado correctamente";

                return RedirectToAction("MostrarUsuarios");

            }

            catch (ApellidoNoValidoException e)
            {
                TempData["Error"] = e.Message;

                return RedirectToAction("Index");
            }
            catch (EmailNoValidoException e)
            {
                TempData["Error"] = e.Message;

                return RedirectToAction("Index");
            }
            catch (NombreNoValidoException e)
            {
                TempData["Error"] = e.Message;

                return RedirectToAction("Index");
            }
            catch (PasswordNoValidoException e)
            {
                TempData["Error"] = e.Message;

                return RedirectToAction("Index");
            }
            catch (RolNoValidoException e)
            {
                TempData["Error"] = e.Message;

                return RedirectToAction("Index");
            }
            catch (UsuarioExisteException e)
            {
                TempData["Error"] = e.Message;

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;

                return RedirectToAction("Index");
            }

        }

        [AdminAuthorize]
        public IActionResult MostrarUsuarios()
        {
            try
            {
                List<DTOUsuario> usuarios = _cuListarUsuario.ListarUsuario();
                return View(usuarios);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [AdminAuthorize]
        public IActionResult ModificarUsuario(int id)
        {
            try
            {

                ModificarUsuarioViewModel viewModel = new ModificarUsuarioViewModel();

                viewModel.Usuario = _cuListarUsuario.ListarUsuarioPorId(id);

                return View(viewModel);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [HttpPost]
        [AdminAuthorize]
        public IActionResult ModificarUsuario(ModificarUsuarioViewModel viewModel)
        {
            try
            {
                viewModel.Usuario.LogueadoId = (int)HttpContext.Session.GetInt32("LogueadoID");

                _cuEditarUsuario.EditarUsuario(viewModel.Usuario);

                TempData["Mensaje"] = "Usuario modificado correctamente";

                return RedirectToAction("MostrarUsuarios");

            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpPost]
        [AdminAuthorize]
        public IActionResult EliminarUsuario(int id)
        {
            try
            {
                int logueadoId = (int)HttpContext.Session.GetInt32("LogueadoID");
                _cuEliminarUsuario.EliminarUsuario(id, logueadoId);
                TempData["Mensaje"] = "Usuario eliminado correctamente.";
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
            }
            return RedirectToAction("MostrarUsuarios");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(DTOUsuario dtoUsuario)
        {
            try
            {
                HttpContext.Session.Clear();

                DTOUsuario u = _cuLogin.ValidarLogin(dtoUsuario);

                if (u.Rol == "Cliente")
                {
                    ViewBag.Mensaje = "Acceso denegado para clientes.";
                    return View();
                }

                HttpContext.Session.SetInt32("LogueadoID", (int)u.Id);
                HttpContext.Session.SetString("LogueadoRol", u.Rol);

                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
                return RedirectToAction("MostrarEnvios");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [FuncionarioAuthorize]
        public IActionResult MostrarEnvios()
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
            return RedirectToAction("MostrarEnvios");
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

                return RedirectToAction("MostrarEnvios");
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
                return RedirectToAction("MostrarEnvios");
            }
        }

    }
}
