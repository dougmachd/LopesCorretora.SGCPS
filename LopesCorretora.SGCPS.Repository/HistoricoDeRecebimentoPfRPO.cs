using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;
using LopesCorretora.SGCPS.Models.ModelosComplementares;


namespace LopesCorretora.SGCPS.Repository
{
	public class HistoricoDeRecebimentoPfRPO
	{
		public static void Cadastrar(HistoricoDeRecebimentoPfMOD historicoDeRecebimentoPfMOD)
		{
			try
			{
				using (SGCPSContext context = new SGCPSContext())
				{
					context.HistoricoDeRecebimentosPf.Add(historicoDeRecebimentoPfMOD);
					context.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void Cadastrar(List<HistoricoDeRecebimentoPfMOD> ListHistoricoDeRecebimentoPfMODs)
		{
			try
			{
				using (SGCPSContext context = new SGCPSContext())
				{
					foreach (var item in ListHistoricoDeRecebimentoPfMODs)
					{
						context.HistoricoDeRecebimentosPf.Add(item);
					}
					context.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static List<HistoricoDeRecebimentoPfMOD> Consultar(DateTime inicio, DateTime fim)
		{
			try
			{
				List<HistoricoDeRecebimentoPfMOD> ListHistoricoDeRecebimentoPfMODs = new List<HistoricoDeRecebimentoPfMOD>();

				using (SGCPSContext context = new SGCPSContext())
				{
					var ie = from pf in context.PessoasFisicas
							 join ppf in context.PlanoPessoasFisicas on pf.PlanoPessoaFisicaId equals ppf.Id
							 join hdr in context.HistoricoDeRecebimentosPf on ppf.NumeroContrato equals hdr.NumeroDoContrato
							 where hdr.DataDaBaixa >= inicio && hdr.DataDaBaixa <= fim
							 select new HistoricoDeRecebimentoPfMOD
							 {
								 Id = hdr.Id,
								 Comissao = hdr.Comissao,
								 DataDaBaixa = hdr.DataDaBaixa,
								 NumeroDaParcela = hdr.NumeroDaParcela,
								 NumeroDoContrato = hdr.NumeroDoContrato,
								 PessoaFisicaId = hdr.PessoaFisicaId,
								 ValorDeEntrada = Convert.ToDecimal(ppf.ValorDeEntrada),
								 PessoaFisica = new PessoaFisicaMOD
								 {
									 Id = pf.Id,
									 Titular = pf.Titular,
									 CPF = pf.CPF,
									 PlanoPessoaFisica = new PlanoPessoaFisicaMOD
									 {
										 PlanoId = ppf.PlanoId,
										 ValorDeEntrada = ppf.ValorDeEntrada
									 }
								 }
							 };
					ListHistoricoDeRecebimentoPfMODs = ie.ToList();
				}
				return ListHistoricoDeRecebimentoPfMODs;
			}
			catch (Exception)
			{
                return new List<HistoricoDeRecebimentoPfMOD>();
                //return null;
			}
		}

		public static List<HistoricoDeRecebimentoPfMOD> Consultar(string NumeroDoContrato)
		{
			try
			{
				List<HistoricoDeRecebimentoPfMOD> comissaoMOD = null;
				using (SGCPSContext context = new SGCPSContext())
				{
					var a = from pf in context.PessoasFisicas
							join hr in context.HistoricoDeRecebimentosPf on pf.Id equals hr.PessoaFisicaId
							join ppf in context.PlanoPessoasFisicas on pf.PlanoPessoaFisicaId equals ppf.Id
							where hr.NumeroDoContrato.Equals(NumeroDoContrato)
							select new HistoricoDeRecebimentoPfMOD
							{
								Id = hr.Id,
								NumeroDaParcela = hr.NumeroDaParcela,
								Comissao = hr.Comissao,
								PessoaFisicaId = pf.Id,
								DataDaBaixa = hr.DataDaBaixa,
								NumeroDoContrato = NumeroDoContrato,
								PessoaFisica = new PessoaFisicaMOD
								{
									Id = pf.Id,
									Titular = pf.Titular,
									CPF = pf.CPF,
									PlanoPessoaFisica = new PlanoPessoaFisicaMOD
									{
										PlanoId = ppf.PlanoId,
										ValorDeEntrada = ppf.ValorDeEntrada
									}
								}
							};
					comissaoMOD = a.ToList();
				}
				return comissaoMOD;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
