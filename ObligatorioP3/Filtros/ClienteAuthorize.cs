using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ObligatorioP3.Filters
{
    public class NoClienteAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userRole = context.HttpContext.Session.GetString("LogueadoRol");
            if (string.IsNullOrEmpty(userRole) || userRole == "Cliente")
            {
                context.Result = new RedirectToActionResult("AccesoDenegado", "Home", null);
            }
            base.OnActionExecuting(context);
        }
    }
}