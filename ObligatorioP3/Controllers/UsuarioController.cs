using Libreria.DTOs.DTOs.DTOsUsuario;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ObligatorioP3.Controllers
{
    public class UsuarioController : Controller
    {

        private ICUAltaUsuario _cuAltaUsuario;
        private ICUListarUsuario _cuListarUsuario;
        private ICUEditarUsuario _cuEditarUsuario;
        private ICUEliminarUsuario _cuEliminarUsuario;

        public UsuarioController(ICUAltaUsuario cuAltaUsuario, ICUListarUsuario cuListarUsuario, ICUEditarUsuario cuEditarUsuario, ICUEliminarUsuario cuEliminarUsuario)
        {
            _cuAltaUsuario = cuAltaUsuario;
            _cuListarUsuario = cuListarUsuario;
            _cuEditarUsuario = cuEditarUsuario;
            _cuEliminarUsuario = cuEliminarUsuario;

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AltaUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AltaUsuario(DTOUsuario dtoUsuario)
        {

            try
            {
                _cuAltaUsuario.AltaUsuario(dtoUsuario);
                ViewBag.Mensaje = "Usuario creado correctamente";
            }

            catch (ApellidoNoValidoException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (EmailNoValidoException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (NombreNoValidoException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (PasswordNoValidoException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (RolNoValido e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (UsuarioExiste e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }


            return View();
        }

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

        public IActionResult ModificarUsuario(int id)
        {
            try
            {
                DTOUsuario usuario = _cuListarUsuario.ListarUsuarioPorId(id);
                return View(usuario);
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
                return View();
            }
        }

        [HttpPost]

        public IActionResult ModificarUsuario(DTOUsuario dtoUsuario)
        {
            try
            {

                _cuEditarUsuario.EditarUsuario(dtoUsuario);
                ViewBag.Mensaje = "Usuario modificado correctamente";
                
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }
            return View();

        }

        //public IActionResult EliminarUsuario(int id)
        //{
        //    try
        //    {
        //        DTOUsuario usuario = _cuListarUsuario.ListarUsuarioPorId(id);
        //        return View(usuario);
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.Mensaje = e.Message;
        //        return View();
        //    }
        //}

        [HttpPost]
        public IActionResult EliminarUsuario(int id)
        {
            try
            {
                _cuEliminarUsuario.EliminarUsuario(id);
                TempData["Mensaje"] = "Usuario eliminado correctamente.";
            }
            catch (Exception e)
            {
                TempData["Error"] = e.Message;
            }
            return RedirectToAction("MostrarUsuarios");
        }
    }
}
