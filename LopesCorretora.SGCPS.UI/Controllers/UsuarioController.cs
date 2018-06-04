using System;
using Microsoft.AspNetCore.Mvc;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Business;
using LopesCorretora.SGCPS.UI.Filtros;
using Microsoft.AspNetCore.Http;

namespace LopesCorretora.SGCPS.UI.Controllers
{
    [AutorizacaoFilter]
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioMOD usuarioMOD)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioBUS.Cadastrar(usuarioMOD);
                    #region mensagem
                    ViewBag.Mensagem = "Usuario cadastrado com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                }
                catch (Exception)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Erro: usuario nao cadastrado!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                }
            }
            else
            {
                #region mensagem
                ViewBag.Mensagem = "Preenchimento invalido!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
            }
            return View(usuarioMOD);
        }

        [HttpGet]
        public IActionResult Alterar(int Id)
        {
            UsuarioMOD usuarioMOD;
            if (Id == 0)
                usuarioMOD = UsuarioBUS.Consultar(Convert.ToInt32(HttpContext.Session.GetString("IdDoUsuario")));
            else
                usuarioMOD = UsuarioBUS.Consultar(Id);

            if (usuarioMOD == null)
            {
                #region mensagem
                ViewBag.Mensagem = "Usuario nao encontrado!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
            }
            return View(usuarioMOD);
        }

        [HttpPost]
        public IActionResult Alterar(UsuarioMOD usuarioMOD)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioBUS.Alterar(usuarioMOD);
                    #region mensagem
                    ViewBag.Mensagem = "Usuario alterado com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                }
                catch (Exception)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Erro: usuario nao alterado!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                }
            }
            else
            {
                #region mensagem
                ViewBag.Mensagem = "Preenchimento invalido!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
            }
            return View(usuarioMOD);
        }
    }
}