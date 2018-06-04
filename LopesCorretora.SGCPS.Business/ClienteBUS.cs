using System;
using System.Collections.Generic;
using System.Text;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;
using LopesCorretora.SGCPS.ViewsModels;
using LopesCorretora.SGCPS.Models.ModelosComplementares;
using System.Linq;

namespace LopesCorretora.SGCPS.Business
{
    public class ClienteBUS
    {
        public static PesquisaClienteVM Pesquisa(string q)
        {
            PesquisaClienteVM pesquisaClienteVM = new PesquisaClienteVM();

            ConverterParaList(pesquisaClienteVM, PessoaJuridicaRPO.Pesquisa(q), PessoaFisicaRPO.Pesquisa(q));

            if (pesquisaClienteVM.ListModelPesquisa.Count > 0)
                pesquisaClienteVM.ListModelPesquisa.OrderBy(x => x.Nome);
            return pesquisaClienteVM;
        }

        public static BalancoVM HistoricoDeRecebimentoMensal()
        {
            string inicio = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
            string fim = DateTime.Now.Year + "-" + DateTime.Now.Month + "-31";

            return new BalancoVM
            {
                ListHistoricoDeRecebimentoPjMODs = HistoricoDeRecebimentoPjRPO.Consultar(Convert.ToDateTime(inicio), Convert.ToDateTime(fim)),
                ListHistoricoDeRecebimentoPfMODs = HistoricoDeRecebimentoPfRPO.Consultar(Convert.ToDateTime(inicio), Convert.ToDateTime(fim))
            };
        }

        public static BalancoVM HistoricoDeRecebimentoAnual()
        {
            string inicio = DateTime.Now.Year + "-01-01";
            string fim = DateTime.Now.Year + "-12-31";

            return new BalancoVM
            {
                ListHistoricoDeRecebimentoPjMODs = HistoricoDeRecebimentoPjRPO.Consultar(Convert.ToDateTime(inicio), Convert.ToDateTime(fim)),
                ListHistoricoDeRecebimentoPfMODs = HistoricoDeRecebimentoPfRPO.Consultar(Convert.ToDateTime(inicio), Convert.ToDateTime(fim))
            };
        }

        private static PesquisaClienteVM ConverterParaList(PesquisaClienteVM pesquisaClienteVM, List<ModelPesquisa> ListPessoaJuridica, List<ModelPesquisa> ListPessoaFisica)
        {
            if (ListPessoaJuridica != null)
            {
                if (ListPessoaJuridica.Count() > 0)
                {
                    foreach (var item in ListPessoaJuridica)
                    {
                        pesquisaClienteVM.ListModelPesquisa.Add(item);
                    }
                }
            }
            if (ListPessoaFisica != null)
            {
                if (ListPessoaFisica.Count() > 0)
                {
                    foreach (var item in ListPessoaFisica)
                    {
                        pesquisaClienteVM.ListModelPesquisa.Add(item);
                    }
                }
            }
            return pesquisaClienteVM;
        }

        public static DarBaixaVM DarBaixaVM(string NumeroDoContrato)
        {
            try
            {
                PessoaFisicaMOD pessoaFisicaMOD = PessoaFisicaRPO.Consultar(NumeroDoContrato);
                if (pessoaFisicaMOD != null)
                {
                    DarBaixaVM a = new DarBaixaVM
                    {
                        ListHistoricoDeRecebimentoPfMODs = HistoricoDeRecebimentoPfRPO.Consultar(NumeroDoContrato).OrderBy(x => x.NumeroDaParcela).ToList(),
						ListComissaoMODs = ComissaoRPO.Listar(pessoaFisicaMOD.PlanoPessoaFisica.PlanoId, "PF").OrderBy(x => x.NumeroDaParcela).ToList(),
                        ObjPessoaFisicaMOD = pessoaFisicaMOD
                    };
                    return a;
                }
                else
                {
                    PlanoPessoaJuridicaMOD planoPessoaJuridicaMOD = PlanoPessoaJuridicaRPO.Consultar(NumeroDoContrato);
                    return new DarBaixaVM
                    {
                        ObjPlanoPessoaJuridicaMOD = planoPessoaJuridicaMOD,
                        ListHistoricoDeRecebimentoPjMODs = HistoricoDeRecebimentoPjRPO.Consultar(NumeroDoContrato).OrderBy(x => x.NumeroDaParcela).ToList(),
                        ListComissaoMODs = ComissaoRPO.Listar(planoPessoaJuridicaMOD.Id, planoPessoaJuridicaMOD.Tipo).OrderBy(x => x.NumeroDaParcela).ToList()
                    };
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void BaixaPj(PlanoPessoaJuridicaMOD ObjPlanoPessoaJuridicaMOD, List<int> parcelas)
        {
            try
            {
                List<HistoricoDeRecebimentoPjMOD> ListHistoricoDeRecebimentoPjMODs = new List<HistoricoDeRecebimentoPjMOD>();
                foreach (var parcela in parcelas)
                {
                    HistoricoDeRecebimentoPjMOD ObjHistoricoDeRecebimentoPjMOD =
                    new HistoricoDeRecebimentoPjMOD
                    {
                        Comissao = ComissaoRPO.Listar(ObjPlanoPessoaJuridicaMOD.Id, ObjPlanoPessoaJuridicaMOD.Tipo).
                        Where(x => x.NumeroDaParcela == parcela).First().Comissao,
                        DataDaBaixa = DateTime.Now,
                        NumeroDaParcela = parcela,
                        NumeroDoContrato = ObjPlanoPessoaJuridicaMOD.NumeroContrato,
                        PessoaJuridicaId = ObjPlanoPessoaJuridicaMOD.PessoaJuridicaId
                    };
                    ListHistoricoDeRecebimentoPjMODs.Add(ObjHistoricoDeRecebimentoPjMOD);
                }
                HistoricoDeRecebimentoPjRPO.Cadastrar(ListHistoricoDeRecebimentoPjMODs);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void BaixaPf(PessoaFisicaMOD ObjPessoaFisicaMOD, List<int> parcelas)
        {
            try
            {
                List<HistoricoDeRecebimentoPfMOD> ListHistoricoDeRecebimentoPfMODs = new List<HistoricoDeRecebimentoPfMOD>();
                foreach (var parcela in parcelas)
                {
                    HistoricoDeRecebimentoPfMOD ObjHistoricoDeRecebimentoPfMOD = new HistoricoDeRecebimentoPfMOD
                    {
                        Comissao = ComissaoRPO.Listar(ObjPessoaFisicaMOD.PlanoPessoaFisicaId, "PF").
                        Where(x => x.NumeroDaParcela == parcela).First().Comissao,
                        DataDaBaixa = DateTime.Now,
                        NumeroDaParcela = parcela,
                        NumeroDoContrato = ObjPessoaFisicaMOD.PlanoPessoaFisica.NumeroContrato,
                        PessoaFisicaId = ObjPessoaFisicaMOD.Id
                    };
                    ListHistoricoDeRecebimentoPfMODs.Add(ObjHistoricoDeRecebimentoPfMOD);
                }
                HistoricoDeRecebimentoPfRPO.Cadastrar(ListHistoricoDeRecebimentoPfMODs);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
