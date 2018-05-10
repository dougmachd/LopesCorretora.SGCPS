using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace LopesCorretora.SGCPS.UI.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object objLoginUsuario = filterContext.HttpContext.Session.GetString("EmailDoUsuario");

            if (objLoginUsuario == null || objLoginUsuario.ToString() == "")
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "LogOut", controller = "Acesso" }));
            }
        }
    }
}
