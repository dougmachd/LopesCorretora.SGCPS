using System;
using Microsoft.AspNetCore.Mvc;
using LopesCorretora.SGCPS.Business;
using LopesCorretora.SGCPS.ViewsModels;
using Microsoft.AspNetCore.Http;
using LopesCorretora.SGCPS.UI.Filtros;
using System.IO;
using System.Collections.Generic;

namespace LopesCorretora.SGCPS.UI.Controllers
{
    [AutorizacaoFilter]
    public class PessoaJuridicaController : Controller
    {
        #region Cadastrar
        [HttpGet]
        public IActionResult Cadastrar()
        {
            try
            {
                CadastrarPessoaJuridicaVM cadastrarPessoaJuridicaVM = PessoaJuridicaBUS.CadastrarPessoaJuridicaVMGet();
                if (cadastrarPessoaJuridicaVM != null)
                {
                    return View(PessoaJuridicaBUS.CadastrarPessoaJuridicaVMGet());
                }
            }
            catch (Exception)
            {
                return View();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarPessoaJuridicaVM cadastrarPessoaJuridicaVM, IFormFile anexo,
            List<int> NumeroDeBeneficiarios = null, List<int> PlanoId = null)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cadastrarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].UsuarioId =
                        Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));

                    #region Salvar Anexo
                    if (anexo != null)
                    {
                        if (Path.GetExtension(anexo.FileName).ToString().ToLower().Equals(".zip"))
                        {
                            long size = anexo.Length;
                            if (anexo.Length > 0)
                            {
                                string strNomeDoAnexo = "Pessoajuridica-" + cadastrarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id.ToString();
                                string savedFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\netcoreapp2.0\\", ""), "Anexos");
                                savedFileName = Path.Combine(savedFileName, Path.GetFileName(strNomeDoAnexo + ".zip"));
                                using (var stream = new FileStream(savedFileName, FileMode.Create))
                                {
                                    anexo.CopyToAsync(stream);
                                }
                                cadastrarPessoaJuridicaVM.ObjPessoaJuridicaMOD.DocumentoAnexo = savedFileName;
                            }
                        }
                        else
                        {
                            #region mensagem
                            ViewBag.Mensagem = "A extensao do arquivo de anexo deve ser [.zip]!";
                            ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                            ViewBag.Class = "alert alert-warning";
                            #endregion
                            return View(PessoaJuridicaBUS.CadastrarPessoaJuridicaVMPost(cadastrarPessoaJuridicaVM));
                        }
                    }
                    #endregion

                    #region mensagem
                    ViewBag.Mensagem = "Pessoa Juridica cadastrada com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                    return View(PessoaJuridicaBUS.CadastrarPessoaJuridica(cadastrarPessoaJuridicaVM, NumeroDeBeneficiarios, PlanoId));
                }
                catch (Exception)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Erro, ao cadastrar pessoa juridica!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                    return View(PessoaJuridicaBUS.CadastrarPessoaJuridicaVMPost(cadastrarPessoaJuridicaVM));
                }
            }
            else
            {
                #region mensagem
                ViewBag.Mensagem = "Preenchimento invalido!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
                return View(PessoaJuridicaBUS.CadastrarPessoaJuridicaVMPost(cadastrarPessoaJuridicaVM));
            }
        }
        #endregion

        #region Alterar
        [HttpGet]
        public IActionResult Alterar(int Id)
        {
            if (Id > 0)
            {
                try
                {
                    return View(PessoaJuridicaBUS.Consultar(Id));
                }
                catch (Exception)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Pessoa Juridica nao encontrada!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                }
            }
            else
            {
                #region mensagem
                ViewBag.Mensagem = "Pessoa Juridica invalida!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
            }
            return View(PessoaJuridicaBUS.AlterarPessoaJuridicaVM());
        }

        [HttpPost]
        public IActionResult Alterar(AlterarPessoaJuridicaVM alterarPessoaJuridicaVM, bool excluir, IFormFile anexo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].UsuarioId =
                        Convert.ToInt32(HttpContext.Session.GetInt32("IdUsuario"));

                    #region Salvar Anexo
                    if (anexo != null)
                    {
                        if (Path.GetExtension(anexo.FileName).ToString().ToLower().Equals(".zip"))
                        {
                            long size = anexo.Length;
                            if (anexo.Length > 0)
                            {
                                string strNomeDoAnexo = "PessoaJuridica-" + alterarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id.ToString();
                                string savedFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\netcoreapp2.0\\", ""), "Anexos");
                                savedFileName = Path.Combine(savedFileName, Path.GetFileName(strNomeDoAnexo + ".zip"));
                                using (var stream = new FileStream(savedFileName, FileMode.Create))
                                {
                                    anexo.CopyToAsync(stream);
                                }
                                alterarPessoaJuridicaVM.ObjPessoaJuridicaMOD.DocumentoAnexo = savedFileName;
                            }
                        }
                        else
                        {
                            PessoaJuridicaBUS.AlterarPessoaJuridicaVM(alterarPessoaJuridicaVM);
                            #region mensagem
                            ViewBag.Mensagem = "A extensao do arquivo de anexo deve ser [.zip]!";
                            ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                            ViewBag.Class = "alert alert-warning";
                            #endregion
                            return View(alterarPessoaJuridicaVM);
                        }
                    }
                    #endregion
                    PessoaJuridicaBUS.AlterarPessoaJuridica(alterarPessoaJuridicaVM);
                    #region mensagem
                    ViewBag.Mensagem = "Pessoa Juridica alterado com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                }
                catch (Exception)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Erro: Pessoa Juridica nao alterada!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                }
            }
            else
            {
                PessoaJuridicaBUS.AlterarPessoaJuridicaVM(alterarPessoaJuridicaVM);
                #region mensagem
                ViewBag.Mensagem = "Preenchimento invalido!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
            }
            return View(alterarPessoaJuridicaVM);
        }
        #endregion
    }
}