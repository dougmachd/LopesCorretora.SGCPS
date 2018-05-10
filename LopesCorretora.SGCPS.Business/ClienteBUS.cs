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
    }
}
