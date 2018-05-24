using System;
using System.Collections.Generic;
using System.Linq;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository.DataAccess;

namespace LopesCorretora.SGCPS.Repository
{
	public class HistoricoDeRecebimentoPjRPO
	{
		public static void Cadastrar(HistoricoDeRecebimentoPjMOD historicoDeRecebimentoPjMOD)
		{
			try
			{
				using (SGCPSContext context = new SGCPSContext())
				{
					context.HistoricoDeRecebimentosPj.Add(historicoDeRecebimentoPjMOD);
					context.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void Cadastrar(List<HistoricoDeRecebimentoPjMOD> ListHistoricoDeRecebimentoPjMOD)
		{
			try
			{
				using (SGCPSContext context = new SGCPSContext())
				{
					foreach (var item in ListHistoricoDeRecebimentoPjMOD)
					{
						context.HistoricoDeRecebimentosPj.Add(item);
					}
					context.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static List<HistoricoDeRecebimentoPjMOD> Consultar(DateTime inicio, DateTime fim)
		{
			try
			{
				List<HistoricoDeRecebimentoPjMOD> comissaoMOD = null;
				using (SGCPSContext context = new SGCPSContext())
				{
					var a = from ppj in context.PlanosPessoasJuridicas
							join pj in context.PessoasJuridicas on ppj.PessoaJuridicaId equals pj.Id
							join hdr in context.HistoricoDeRecebimentosPj on ppj.NumeroContrato equals hdr.NumeroDoContrato
							where hdr.DataDaBaixa >= inicio && hdr.DataDaBaixa <= fim
							select new HistoricoDeRecebimentoPjMOD
							{
								Id = hdr.Id,
								ValorDeEntrada = Convert.ToDecimal(ppj.ValorDeEntrada),
								NumeroDaParcela = hdr.NumeroDaParcela,
								Comissao = hdr.Comissao,
								PessoaJuridicaId = hdr.Id,
								DataDaBaixa = hdr.DataDaBaixa,
								NumeroDoContrato = hdr.NumeroDoContrato,
								PessoaJuridica = new PessoaJuridicaMOD
								{
									Id = pj.Id,
									RazaoSocial = pj.RazaoSocial,
									CNPJ = pj.CNPJ
								}
							};
					comissaoMOD = a.ToList();
				}
				return comissaoMOD;
				//return context.HistoricoDeRecebimentosPj.Where(x => x.DataDaBaixa >= inicio && x.DataDaBaixa <= fim).ToList();
			}
			catch (Exception)
			{
				//return null;
				return new List<HistoricoDeRecebimentoPjMOD>();
            }
		}

		public static List<HistoricoDeRecebimentoPjMOD> Consultar(int PessoaJuridicaId)
		{
			try
			{
				using (SGCPSContext context = new SGCPSContext())
				{
					return context.HistoricoDeRecebimentosPj.Where(x => x.PessoaJuridicaId == PessoaJuridicaId).OrderByDescending(x => x.NumeroDoContrato).ToList();
				}
			}
			catch (Exception)
			{
				return null;
			}
		}

		public static List<HistoricoDeRecebimentoPjMOD> Consultar(string NumeroDoContrato)
		{
			try
			{
				List<HistoricoDeRecebimentoPjMOD> comissaoMOD = null;
				using (SGCPSContext context = new SGCPSContext())
				{
					var a = from pj in context.PessoasJuridicas
							join hr in context.HistoricoDeRecebimentosPj on pj.Id equals hr.PessoaJuridicaId
							where hr.NumeroDoContrato.Equals(NumeroDoContrato)
							select new HistoricoDeRecebimentoPjMOD
							{
								Id = hr.Id,
								NumeroDaParcela = hr.NumeroDaParcela,
								Comissao = hr.Comissao,
								PessoaJuridicaId = pj.Id,
								DataDaBaixa = hr.DataDaBaixa,
								NumeroDoContrato = NumeroDoContrato,
								PessoaJuridica = new PessoaJuridicaMOD
								{
									Id = pj.Id,
									RazaoSocial = pj.RazaoSocial,
									CNPJ = pj.CNPJ
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
