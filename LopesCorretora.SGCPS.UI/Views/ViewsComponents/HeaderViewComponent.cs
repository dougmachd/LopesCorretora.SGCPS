using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;


namespace LopesCorretora.SGCPS.UI.Views.ViewsComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.NomeUsuario = HttpContext.Session.GetString("NomeDoUsuario").ToString();
            return View("Header.cshtml");
        }
    }
}
