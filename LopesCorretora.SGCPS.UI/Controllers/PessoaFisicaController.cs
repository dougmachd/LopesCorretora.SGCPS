using System;
using Microsoft.AspNetCore.Mvc;
using LopesCorretora.SGCPS.Business;
using LopesCorretora.SGCPS.ViewsModels;
using LopesCorretora.SGCPS.UI.Filtros;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace LopesCorretora.SGCPS.UI.Controllers
{
    [AutorizacaoFilter]
    public class PessoaFisicaController : Controller
    {
        #region Cadastrar Pessoa Fisica
        [HttpGet]
        public IActionResult Cadastrar()
        {
            CadastrarPessoaFisicaVM cadastrarPessoaFisicaVM = PessoaFisicaBUS.CadastrarPessoaFisicaVM();
            if (cadastrarPessoaFisicaVM != null)
            {
                return View(cadastrarPessoaFisicaVM);
            }
            else
            {
                #region mensagem
                ViewBag.Mensagem = "Erro!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
                return View("retornar view de erro 404");
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarPessoaFisicaVM cadastrarPessoaFisicaVM, IFormFile anexo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    #region Salvar Anexo
                    if (anexo != null)
                    {
                        if (Path.GetExtension(anexo.FileName).ToString().ToLower().Equals(".zip"))
                        {
                            long size = anexo.Length;
                            if (anexo.Length > 0)
                            {
                                string strNomeDoAnexo = "PessoaFisica-" + cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD.Id.ToString();
                                string savedFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\netcoreapp2.0\\", ""), "Anexos");
                                savedFileName = Path.Combine(savedFileName, Path.GetFileName(strNomeDoAnexo + ".zip"));
                                using (var stream = new FileStream(savedFileName, FileMode.Create))
                                {
                                    anexo.CopyToAsync(stream);
                                }
                                cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD.DocumentosAnexo = savedFileName;
                            }
                        }
                        else
                        {
                            CadastrarPessoaFisicaVM ObjCadastrarPessoaFisicaVM = (CadastrarPessoaFisicaVM)PessoaFisicaBUS.CadastrarPessoaFisicaVM();
                            ObjCadastrarPessoaFisicaVM.ObjPessoaFisicaMOD = cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD;
                            ObjCadastrarPessoaFisicaVM.LisContatoPessoaFisicaMOD = cadastrarPessoaFisicaVM.LisContatoPessoaFisicaMOD;
                            ObjCadastrarPessoaFisicaVM.LisDependentePessoaFisicaMOD = cadastrarPessoaFisicaVM.LisDependentePessoaFisicaMOD;
                            #region mensagem
                            ViewBag.Mensagem = "A extensao do arquivo de anexo deve ser [.zip]!";
                            ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                            ViewBag.Class = "alert alert-warning";
                            #endregion
                            return View(ObjCadastrarPessoaFisicaVM);
                        }
                    }
                    #endregion
                    PessoaFisicaBUS.ActionCadastrarPessoaFisica(cadastrarPessoaFisicaVM);
                    #region mensagem
                    ViewBag.Mensagem = "Cliente Pessoa Fisica cadastrada com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                    return View(PessoaFisicaBUS.PopularVM(cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD));
                }
                catch (Exception)
                {
                    #region mensagem
                    ViewBag.Mensagem = "Erro: Cliente nao cadastrado!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                    return View(cadastrarPessoaFisicaVM);
                }
            }
            else
            {
                CadastrarPessoaFisicaVM ObjCadastrarPessoaFisicaVM = (CadastrarPessoaFisicaVM)PessoaFisicaBUS.CadastrarPessoaFisicaVM();
                ObjCadastrarPessoaFisicaVM.ObjPessoaFisicaMOD = cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD;
                ObjCadastrarPessoaFisicaVM.LisContatoPessoaFisicaMOD = cadastrarPessoaFisicaVM.LisContatoPessoaFisicaMOD;
                ObjCadastrarPessoaFisicaVM.LisDependentePessoaFisicaMOD = cadastrarPessoaFisicaVM.LisDependentePessoaFisicaMOD;
                #region mensagem
                ViewBag.Mensagem = "Preenchimento invalido!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
                return View(ObjCadastrarPessoaFisicaVM);
            }
        }
        #endregion

        #region Alterar Pessoa Fisica
        [HttpGet]
        public IActionResult Alterar(int Id)
        {
            AlterarPessoaFisicaVM alterarPessoaFisicaVM = PessoaFisicaBUS.AlterarPessoaFisicaVM(Id);
            if (alterarPessoaFisicaVM != null)
            {
                if (alterarPessoaFisicaVM.ObjPessoaFisicaMOD != null)
                {
                    return View(alterarPessoaFisicaVM);
                }
                else
                {
                    #region mensagem
                    ViewBag.Mensagem = "Pessoa fisica nao encontrada!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                    return View(alterarPessoaFisicaVM);
                }
            }
            else
            {
                #region mensagem
                ViewBag.Mensagem = "Pessoa fisica nao encontrada!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
                ViewBag.Mensagem = "Pessoa fisica nao encontrada!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                return View(alterarPessoaFisicaVM);
            }
        }

        [HttpPost]
        public IActionResult Alterar(AlterarPessoaFisicaVM ObjAlterarPessoaFisicaVM, IFormFile anexo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    #region Salvar Anexo
                    if (anexo != null)
                    {
                        if (Path.GetExtension(anexo.FileName).ToString().ToLower().Equals(".zip"))
                        {
                            long size = anexo.Length;
                            if (anexo.Length > 0)
                            {
                                string strNomeDoAnexo = "PessoaFisica-" + ObjAlterarPessoaFisicaVM.ObjPessoaFisicaMOD.Id.ToString();
                                string savedFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\netcoreapp2.0\\", ""), "Anexos");
                                savedFileName = Path.Combine(savedFileName, Path.GetFileName(strNomeDoAnexo + ".zip"));
                                using (var stream = new FileStream(savedFileName, FileMode.Create))
                                {
                                    anexo.CopyToAsync(stream);
                                }
                                ObjAlterarPessoaFisicaVM.ObjPessoaFisicaMOD.DocumentosAnexo = savedFileName;
                            }
                        }
                        else
                        {
                            AlterarPessoaFisicaVM alterarPessoaFisicaVM = PessoaFisicaBUS.AlterarPessoaFisicaVM(ObjAlterarPessoaFisicaVM.ObjPessoaFisicaMOD.Id);
                            #region mensagem
                            ViewBag.Mensagem = "A extensao do arquivo de anexo deve ser [.zip]!";
                            ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                            ViewBag.Class = "alert alert-warning";
                            #endregion
                            return View(alterarPessoaFisicaVM);
                        }
                    }
                    #endregion
                    PessoaFisicaBUS.ActionAlterarPessoaFisica(ObjAlterarPessoaFisicaVM);
                    #region mensagem
                    ViewBag.Mensagem = "Pessoa fisica alterada com sucesso!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-success";
                    #endregion
                    return View(PessoaFisicaBUS.AlterarPessoaFisicaVM(ObjAlterarPessoaFisicaVM.ObjPessoaFisicaMOD.Id));
                }
                catch (Exception)
                {
                    PessoaFisicaBUS.ActionAlterarPessoaFisica(ObjAlterarPessoaFisicaVM);
                    #region mensagem
                    ViewBag.Mensagem = "Pessoa fisica nao alterada!";
                    ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                    ViewBag.Class = "alert alert-danger";
                    #endregion
                    return View(PessoaFisicaBUS.AlterarPessoaFisicaVM(ObjAlterarPessoaFisicaVM.ObjPessoaFisicaMOD.Id));
                }
            }
            else
            {
                AlterarPessoaFisicaVM alterarPessoaFisicaVM = PessoaFisicaBUS.AlterarPessoaFisicaVM(ObjAlterarPessoaFisicaVM.ObjPessoaFisicaMOD.Id);
                #region mensagem
                ViewBag.Mensagem = "Preenchimento Invalido!";
                ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
                ViewBag.Class = "alert alert-danger";
                #endregion
                return View(alterarPessoaFisicaVM);
            }
        }
        #endregion
    }
}