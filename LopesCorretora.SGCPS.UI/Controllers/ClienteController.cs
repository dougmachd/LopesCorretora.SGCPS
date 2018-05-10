using System;
using Microsoft.AspNetCore.Mvc;
using LopesCorretora.SGCPS.Business;
using LopesCorretora.SGCPS.ViewsModels;
using LopesCorretora.SGCPS.UI.Filtros;
using System.IO;

namespace LopesCorretora.SGCPS.UI.Controllers
{
    [AutorizacaoFilter]
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Pesquisa()
        {
            return View(new PesquisaClienteVM());
        }

        [HttpPost]
        public IActionResult Pesquisa(string q)
        {
            try
            {
                PesquisaClienteVM pesquisaClienteVM = ClienteBUS.Pesquisa(q);
                if (pesquisaClienteVM.ListModelPesquisa.Count == 0)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Nenhum resultado encontrado!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-warning";
                    #endregion
                }
                else if (pesquisaClienteVM.ListModelPesquisa != null)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Erro!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                }
                else
                {
                    #region mensagem
                    ViewBag.Mensagem = pesquisaClienteVM.ListModelPesquisa.Count + "Resultados encontrados!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                }
                return View(pesquisaClienteVM);

            }
            catch (Exception)
            {
                #region mensagem
                ViewBag.Mensagem = "Usuario nao encontrado!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
                return View(new PesquisaClienteVM());
            }
        }

        [HttpGet]
        public RedirectToActionResult Redirecionar(int Id, string Tipo)
        {
            if (Tipo.Equals("PessoaJuridica"))
            {
                return RedirectToAction("Alterar", "PessoaJuridica", new { Id });
            }
            else
            {
                return RedirectToAction("Alterar", "PessoaFisica", new { Id });
            }
        }

        public ActionResult DownloadDocumento(int Id, string Tipo, string DocumentoAnexo)
        {
            try
            {
                string nome = "";
                if (DocumentoAnexo.Contains(".zip"))
                {
                    nome = Tipo + "-" + Id + ".zip";
                }

                if (DocumentoAnexo != null && DocumentoAnexo != "")
                {
                    FileStream stream = new FileStream(DocumentoAnexo, FileMode.Open);
                    return File(stream, "Baixar", DocumentoAnexo = nome);
                }
            }
            catch (Exception)
            {
                ViewBag.msgrerg = "404 ";
                return PartialView("PartialErrors");
            }
            return null;
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}