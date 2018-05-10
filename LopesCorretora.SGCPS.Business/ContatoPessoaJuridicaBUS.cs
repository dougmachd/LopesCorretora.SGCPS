using System;
using System.Collections.Generic;
using System.Text;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;
using LopesCorretora.SGCPS.ViewsModels;

namespace LopesCorretora.SGCPS.Business
{
    public class ContatoPessoaJuridicaBUS
    {
        public static void AlterarContatosPessoasJuridicas(List<ContatoPessoaJuridicaMOD> lisContatoPessoaJuridicaMOD)
        {
            foreach (var item in lisContatoPessoaJuridicaMOD)
            {
                ContatoPessoaJuridicaRPO.Alterar(item);
            }
        }
    }
}
