using System;
using Microsoft.AspNetCore.Mvc;
using LopesCorretora.SGCPS.Business;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.UI.Filtros;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace LopesCorretora.SGCPS.UI.Controllers
{
    [AutorizacaoFilter]
    public class PlanoController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new PlanoMOD());
        }

        [HttpPost]
        public IActionResult Cadastrar(PlanoMOD planoMOD)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PlanoBUS.CadastrarPlano(planoMOD);
                    #region mensagem
                    ViewBag.Mensagem = "Plano cadastrado com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                    return View();
                }
                catch (Exception)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Erro ao cadastrar plano!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                    return View(planoMOD);
                }
            }
            else
            {
                #region mensagem
                ViewBag.Mensagem = "Preenchimento invalido!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
                return View(planoMOD);
            }
        }

        [HttpGet]
        public IActionResult Alterar(int Id)
        {
            return View(PlanoBUS.Buscar(Id));
        }

        [HttpPost]
        public IActionResult Alterar(PlanoMOD planoMOD)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PlanoBUS.Alterar(planoMOD);
                    #region mensagem
                    ViewBag.Mensagem = "Plano alterado com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                }
                catch (Exception)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Erro na alteracao do plano!";
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
            return View(planoMOD);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return View(PlanoBUS.ListarPlanos());
        }
    }
}
