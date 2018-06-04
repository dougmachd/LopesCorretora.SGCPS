using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Business;
using Microsoft.AspNetCore.Authorization;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;

namespace LopesCorretora.SGCPS.UI.Controllers
{
    public class AcessoController : Controller
    {
        [Authorize]
        public IActionResult Login()
        {
            UsuarioMOD usuarioMOD = new UsuarioMOD(this.User);
            UsuarioBUS.RetornarEmail(usuarioMOD);
            usuarioMOD = UsuarioBUS.IsValid(usuarioMOD);
            HttpContext.Session.GetString("EmailDoUsuario");
            if (usuarioMOD != null)
            {
                HttpContext.Session.SetString("EmailDoUsuario", usuarioMOD.Email.ToString());
                HttpContext.Session.SetString("IdDoUsuario", usuarioMOD.Id.ToString());
                HttpContext.Session.SetString("NomeDoUsuario", usuarioMOD.Nome.ToString());
            }
            return RedirectToAction("Dashboard", "Home", null);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("EmailDoUsuario", "");
            HttpContext.Session.SetString("IdDoUsuario", "");
            HttpContext.Session.SetString("NomeDoUsuario", "");
            return RedirectToAction("Home", "Home", "");
        }
    }
}


//public IActionResult Google(UsuarioMOD usuarioMOD)
//{
//    usuarioMOD = UsuarioBUS.IsValid(usuarioMOD);
//    if (usuarioMOD != null)
//    {
//        HttpContext.Session.SetString("EmailDoUsuario", usuarioMOD.Email.ToString());
//        HttpContext.Session.SetString("IdDoUsuario", usuarioMOD.Id.ToString());
//        HttpContext.Session.SetString("NomeDoUsuario", usuarioMOD.Nome.ToString());
//    }
//    return View();
//}