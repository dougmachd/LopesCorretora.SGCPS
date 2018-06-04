using Microsoft.AspNetCore.Mvc;
using LopesCorretora.SGCPS.UI.Filtros;
using Microsoft.AspNetCore.Http;
using Google.Apis.Calendar.v3;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using Google.Apis.Util.Store;
using System.Text;
using Google.Apis.Services;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;
using Google.Apis.Calendar.v3.Data;
using System;

namespace LopesCorretora.SGCPS.UI.Controllers
{
    public class HomeController : Controller
    {
        [AutorizacaoFilter]
        public IActionResult Dashboard()
        {
            HttpContext.Session.SetInt32("IdUsuario", 1);
            ViewBag.EmailUsuario = HttpContext.Session.GetString("EmailDoUsuario").ToString();
            return View();
        }

        
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Header()
        {
            ViewBag.Usuario = HttpContext.Session.GetString("EmailDoUsuario");
            return PartialView();
        }
    }
}
