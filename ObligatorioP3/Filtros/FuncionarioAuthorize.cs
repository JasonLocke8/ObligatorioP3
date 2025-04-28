using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ObligatorioP3.Filters
{
    public class FuncionarioAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userRole = context.HttpContext.Session.GetString("LogueadoRol");
            if (string.IsNullOrEmpty(userRole) || (userRole != "Administrador" && userRole != "Funcionario"))
            {
                context.Result = new RedirectToActionResult("AccesoDenegado", "Home", null);
            }
            base.OnActionExecuting(context);
        }
    }
}