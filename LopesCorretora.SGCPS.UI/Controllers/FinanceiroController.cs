using Microsoft.AspNetCore.Mvc;
using LopesCorretora.SGCPS.UI.Filtros;
using LopesCorretora.SGCPS.ViewsModels;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Business;
using System.Collections.Generic;
using System;

namespace LopesCorretora.SGCPS.UI.Controllers
{
	[AutorizacaoFilter]
	public class FinanceiroController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		#region Relatorios
		[HttpGet]
		public IActionResult BalancoAnual()
		{
			BalancoVM balancoVM = ClienteBUS.HistoricoDeRecebimentoAnual();
			balancoVM.ListHistoricoDeDespesaMODs = HistoricoDeDespesaBUS.HistoricoDeDespesaMensal();
			ViewBag.ClassFirst = balancoVM.TotalEntrada > balancoVM.TotalSaida ? "progress-bar progress-bar-info" : "progress-bar progress-bar-danger";
			ViewBag.ClassSecond = balancoVM.TotalEntrada < balancoVM.TotalSaida ? "progress-bar progress-bar-warning" : "progress-bar progress-bar-danger";
			ViewBag.ClassThird = balancoVM.TotalEntrada > balancoVM.TotalSaida ? "progress-bar progress-bar-success" : "progress-bar progress-bar-danger";
			return View(balancoVM);
		}

		[HttpGet]
		public IActionResult BalancoMensal()
		{
			BalancoVM balancoVM = ClienteBUS.HistoricoDeRecebimentoMensal();
			balancoVM.ListHistoricoDeDespesaMODs = HistoricoDeDespesaBUS.HistoricoDeDespesaMensal();
			ViewBag.ClassFirst = balancoVM.TotalEntrada > balancoVM.TotalSaida ? "progress-bar progress-bar-info" : "progress-bar progress-bar-danger";
			ViewBag.ClassSecond = balancoVM.TotalEntrada < balancoVM.TotalSaida ? "progress-bar progress-bar-warning" : "progress-bar progress-bar-danger";
			ViewBag.ClassThird = balancoVM.TotalEntrada > balancoVM.TotalSaida ? "progress-bar progress-bar-success" : "progress-bar progress-bar-danger";
			return View(balancoVM);
		}
		#endregion

		#region Controle de despesas
		[HttpGet]
		public IActionResult ControleDeDespesas()
		{
			return View(new ControleDeDespesasVM
			{
				ObjHistoricoDeDepesaMOD = new HistoricoDeDespesaMOD
				{
					DataDaBaixa = DateTime.Now
				}
			});
		}

		[HttpPost]
		public IActionResult ControleDeDespesas(List<string> Tipos, List<string> Valores, List<string> Datas)
		{
			if (ModelState.IsValid)
			{
				try
				{
					HistoricoDeDespesaBUS.Cadastrar(Tipos, Valores, Datas);
					#region mensagem
					ViewBag.Mensagem = Tipos.Count + (Tipos.Count == 1 ? " despesa cadastrada!" : " despesas cadastradas!");
					ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
					ViewBag.Class = "alert alert-success";
					#endregion
				}
				catch (Exception)
				{
					#region mensagem
					ViewBag.Mensagem = "Erro ao cadastrar despesas!";
					ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
					ViewBag.Class = "alert alert-danger";
					#endregion
				}
			}
			return View(new ControleDeDespesasVM());
		}
		#endregion

		#region Baixa
		[HttpGet]
		public IActionResult DarBaixa(string NumeroDoContrato = null)
		{
			if (NumeroDoContrato != null)
			{
				return View(ClienteBUS.DarBaixaVM(NumeroDoContrato));
			}
			else
			{
				#region mensagem
				ViewBag.Mensagem = "Cliente invalido!";
				ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
				ViewBag.Class = "alert alert-warning";
				#endregion
			}
			return View(null);
		}

		[HttpPost]
		public IActionResult DarBaixa(DarBaixaVM darBaixaVM, List<int> parcelas)
		{
			if (darBaixaVM.ObjPessoaFisicaMOD != null)
			{
				try
				{
					ClienteBUS.BaixaPf(darBaixaVM.ObjPessoaFisicaMOD, parcelas);
					#region mensagem
					ViewBag.Mensagem = "Baixa em Pessoa Fisica realizada com sucesso!";
					ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
					ViewBag.Class = "alert alert-success";
					#endregion
					return View(ClienteBUS.DarBaixaVM(darBaixaVM.ObjPessoaFisicaMOD.PlanoPessoaFisica.NumeroContrato));
				}
				catch (System.Exception)
				{
					#region mensagem
					ViewBag.Mensagem = "Baixa em Pessoa Fisica nao realizada, tente mais tarde!";
					ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
					ViewBag.Class = "alert alert-danger";
					#endregion
					return View(ClienteBUS.DarBaixaVM(darBaixaVM.ObjPessoaFisicaMOD.PlanoPessoaFisica.NumeroContrato));
				}
			}
			else if (darBaixaVM.ObjPlanoPessoaJuridicaMOD != null)
			{
				try
				{
					ClienteBUS.BaixaPj(darBaixaVM.ObjPlanoPessoaJuridicaMOD, parcelas);
					#region mensagem
					ViewBag.Mensagem = "Baixa em Pessoa Fisica realizada com sucesso!";
					ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
					ViewBag.Class = "alert alert-success";
					#endregion
					return View(ClienteBUS.DarBaixaVM(darBaixaVM.ObjPlanoPessoaJuridicaMOD.NumeroContrato));
				}
				catch (System.Exception)
				{
					#region mensagem
					ViewBag.Mensagem = "Baixa em Pessoa Juridica nao realizada, tente mais tarde!";
					ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
					ViewBag.Class = "alert alert-danger";
					#endregion
					return View(ClienteBUS.DarBaixaVM(darBaixaVM.ObjPlanoPessoaJuridicaMOD.NumeroContrato));
				}
			}
			else
			{
				#region mensagem
				ViewBag.Mensagem = "Erro ao dar baixa, tente mais tarde!";
				ViewBag.Style = "display:block; text-align:center; margin-top: 5%";
				ViewBag.Class = "alert alert-danger";
				#endregion
			}
			return View();
		}
		#endregion
	}
}