using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LopesCorretora.SGCPS.Business;
using LopesCorretora.SGCPS.UI.Filtros;
using LopesCorretora.SGCPS.ViewsModels;
using Microsoft.AspNetCore.Mvc;

namespace LopesCorretora.SGCPS.UI.Controllers
{
    [AutorizacaoFilter]
    public class ComissaoController : Controller
    {

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(ComissaoBUS.ComissaoVM());
        }

        [HttpPost]
        public IActionResult Cadastrar(ComissaoVM comissaoVM, List<string> Tipos, List<int> NumeroDaParcela, List<int> Comissao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ComissaoBUS.Cadastrar(comissaoVM.ObjComissaoMOD.PlanoId, Tipos, NumeroDaParcela, Comissao);
                    comissaoVM = ComissaoBUS.ComissaoVM(comissaoVM.ObjComissaoMOD);
                    #region mensagem
                    ViewBag.Mensagem = "Comissao cadastrada com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                }
                catch (Exception)
                {
                    comissaoVM = ComissaoBUS.ComissaoVM(comissaoVM.ObjComissaoMOD);
                    #region mensagem
                    ViewBag.Mensagem = "Erro ao cadastrar comissao!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                }
            }
            else
            {
                comissaoVM = ComissaoBUS.ComissaoVM(comissaoVM.ObjComissaoMOD);
                #region mensagem
                ViewBag.Mensagem = "Preenchimento invalido!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
            }
            return View(comissaoVM);
        }

        [HttpGet]
        public JsonResult ReturnTipos(int Id)
        {
            return Json(ComissaoBUS.ReturnTipos(Id));
        }
    }
}