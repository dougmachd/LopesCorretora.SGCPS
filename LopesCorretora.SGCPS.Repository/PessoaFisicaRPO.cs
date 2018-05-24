using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;
using LopesCorretora.SGCPS.Models.ModelosComplementares;

namespace LopesCorretora.SGCPS.Repository
{
	public class PessoaFisicaRPO
	{
		public static void Alterar(PessoaFisicaMOD pessoaFisicaMOD)
		{
			try
			{
				using (SGCPSContext context = new SGCPSContext())
				{
					PessoaFisicaMOD ObjPessoaFisicaMOD = context.PessoasFisicas.Where(x => x.Id == pessoaFisicaMOD.Id).First();
					ObjPessoaFisicaMOD.CPF = pessoaFisicaMOD.CPF;
					ObjPessoaFisicaMOD.DataDeNascimento = pessoaFisicaMOD.DataDeNascimento;
					ObjPessoaFisicaMOD.DocumentosAnexo = pessoaFisicaMOD.DocumentosAnexo;
					ObjPessoaFisicaMOD.Email = pessoaFisicaMOD.Email;
					ObjPessoaFisicaMOD.EstadoCivil = pessoaFisicaMOD.EstadoCivil;
					ObjPessoaFisicaMOD.MaeDoTitular = pessoaFisicaMOD.MaeDoTitular;
					ObjPessoaFisicaMOD.NumeroDoSUS = pessoaFisicaMOD.NumeroDoSUS;
					ObjPessoaFisicaMOD.Observacoes = pessoaFisicaMOD.Observacoes;
					ObjPessoaFisicaMOD.ResponsavelGeral = pessoaFisicaMOD.ResponsavelGeral;
					ObjPessoaFisicaMOD.RG = pessoaFisicaMOD.RG;
					ObjPessoaFisicaMOD.Sexo = pessoaFisicaMOD.Sexo;
					ObjPessoaFisicaMOD.StatusId = pessoaFisicaMOD.StatusId;
					ObjPessoaFisicaMOD.Titular = pessoaFisicaMOD.Titular;
					EnderecoRPO.Alterar(pessoaFisicaMOD.Endereco);
					context.PessoasFisicas.Update(ObjPessoaFisicaMOD);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public static List<ModelPesquisa> Pesquisa(string q)
		{
			try
			{
				IEnumerable<ModelPesquisa> ListPessoaFisicaMOD;
				List<ModelPesquisa> list = new List<ModelPesquisa>();

				using (SGCPSContext context = new SGCPSContext())
				{
					ListPessoaFisicaMOD = from pf in context.PessoasFisicas
										  join ppf in context.PlanoPessoasFisicas on pf.PlanoPessoaFisicaId equals ppf.Id
										  where pf.Titular.ToString().ToLower().Contains(q.ToString().ToLower()) ||
										  pf.PlanoPessoaFisica.NumeroContrato.ToString().ToLower().Equals(q.ToString().ToLower()) ||
										  pf.CPF.ToString().ToLower().Equals(q.ToString().ToLower()) ||
										  pf.Observacoes.ToString().ToLower().Contains(q.ToString().ToLower())
										  select new ModelPesquisa
										  {
											  Nome = pf.Titular,
											  Documento = pf.CPF,
											  Observacoes = pf.Observacoes,
											  NumeroContrato = pf.PlanoPessoaFisica.NumeroContrato,
											  Id = pf.Id,
											  Tipo = "PessoaFisica",
											  DocumentoAnexo = pf.DocumentosAnexo
										  };

					if (ListPessoaFisicaMOD.Count() > 0)
					{
						foreach (var item in ListPessoaFisicaMOD)
						{
							list.Add(item);
						}
					}
				}
				return list;
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public static void Cadastrar(PessoaFisicaMOD pessoaFisicaMOD)
		{
			try
			{
				using (SGCPSContext context = new SGCPSContext())
				{
					context.PessoasFisicas.Add(pessoaFisicaMOD);
					context.SaveChanges();
				}
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public static PessoaFisicaMOD Consultar(int Id)
		{
			try
			{
				IEnumerable<PessoaFisicaMOD> obj;
				PessoaFisicaMOD pessoaFisicaMOD;
				using (SGCPSContext context = new SGCPSContext())
				{
					obj = from pf in context.PessoasFisicas
						  join ppf in context.PlanoPessoasFisicas on pf.PlanoPessoaFisicaId equals ppf.Id
						  join p in context.Planos on ppf.PlanoId equals p.Id
						  join dpf in context.DependentesPessoasFisicas on pf.Id equals dpf.PessoaFisicaId
						  join e in context.Enderecos on pf.EnderecoId equals e.Id
						  join cpf in context.ContatosPessoasFisicas on pf.Id equals cpf.PessoaFisicaId
						  where pf.Id.Equals(Id)
						  select new PessoaFisicaMOD
						  {
							  Id = pf.Id,
							  Titular = pf.Titular,
							  CPF = pf.CPF,
							  DataDeNascimento = pf.DataDeNascimento,
							  Email = pf.Email,
							  Endereco = new EnderecoMOD
							  {
								  Id = e.Id,
								  Bairro = e.Bairro,
								  CEP = e.CEP,
								  Cidade = e.Cidade,
								  Complemento = e.Complemento,
								  Numero = e.Numero,
								  Referencia = e.Referencia,
								  Rua = e.Rua,
								  UF = e.UF
							  },
							  EstadoCivil = pf.EstadoCivil,
							  MaeDoTitular = pf.MaeDoTitular,
							  NumeroDoSUS = pf.NumeroDoSUS,
							  Observacoes = pf.Observacoes,
							  PlanoPessoaFisica = new PlanoPessoaFisicaMOD
							  {
								  PlanoId = p.Id,
								  NumeroContrato = ppf.NumeroContrato,
								  ValorDeEntrada = ppf.ValorDeEntrada,
								  NumeroDeParcelas = ppf.NumeroDeParcelas
							  },
							  PlanoPessoaFisicaId = pf.PlanoPessoaFisicaId,
							  ResponsavelGeral = pf.ResponsavelGeral,
							  RG = pf.RG,
							  Sexo = pf.Sexo,
							  StatusId = pf.StatusId
						  };
					pessoaFisicaMOD = obj.First();
				}
				return pessoaFisicaMOD;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public static PessoaFisicaMOD Consultar(string NumeroDoContrato)
		{
			try
			{
				IEnumerable<PessoaFisicaMOD> obj;
				PessoaFisicaMOD pessoaFisicaMOD;
				using (SGCPSContext context = new SGCPSContext())
				{
					obj = from pf in context.PessoasFisicas
						  join ppf in context.PlanoPessoasFisicas on pf.PlanoPessoaFisicaId equals ppf.Id
						  join p in context.Planos on ppf.PlanoId equals p.Id
						  join dpf in context.DependentesPessoasFisicas on pf.Id equals dpf.PessoaFisicaId
						  join e in context.Enderecos on pf.EnderecoId equals e.Id
						  join cpf in context.ContatosPessoasFisicas on pf.Id equals cpf.PessoaFisicaId
						  where ppf.NumeroContrato.Equals(NumeroDoContrato)
						  select new PessoaFisicaMOD
						  {
							  Id = pf.Id,
							  Titular = pf.Titular,
							  CPF = pf.CPF,
							  DataDeNascimento = pf.DataDeNascimento,
							  Email = pf.Email,
							  Endereco = new EnderecoMOD
							  {
								  Id = e.Id,
								  Bairro = e.Bairro,
								  CEP = e.CEP,
								  Cidade = e.Cidade,
								  Complemento = e.Complemento,
								  Numero = e.Numero,
								  Referencia = e.Referencia,
								  Rua = e.Rua,
								  UF = e.UF
							  },
							  EstadoCivil = pf.EstadoCivil,
							  MaeDoTitular = pf.MaeDoTitular,
							  NumeroDoSUS = pf.NumeroDoSUS,
							  Observacoes = pf.Observacoes,
							  PlanoPessoaFisica = new PlanoPessoaFisicaMOD
							  {
								  PlanoId = p.Id,
								  NumeroContrato = ppf.NumeroContrato,
								  ValorDeEntrada = ppf.ValorDeEntrada,
								  NumeroDeParcelas = ppf.NumeroDeParcelas
							  },
							  PlanoPessoaFisicaId = pf.PlanoPessoaFisicaId,
							  ResponsavelGeral = pf.ResponsavelGeral,
							  RG = pf.RG,
							  Sexo = pf.Sexo,
							  StatusId = pf.StatusId
						  };
					pessoaFisicaMOD = obj.First();
				}
				return pessoaFisicaMOD;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		//public static List<PessoaFisicaMOD> Consultar(string Titular)
		//{
		//	try
		//	{
		//		using (SGCPSContext context = new SGCPSContext())
		//		{
		//			return (List<PessoaFisicaMOD>)context.PessoasFisicas.Where(x => x.Titular == Titular);
		//		}
		//	}
		//	catch (Exception)
		//	{
		//		throw;
		//	}
		//}
	}
}
