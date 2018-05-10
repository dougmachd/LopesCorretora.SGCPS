using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;

namespace LopesCorretora.SGCPS.Business
{
    public class PlanoPessoaJuridicaBUS
    {
        public static void CadastrarPlanoPessoaJuridica(List<PlanoPessoaJuridicaMOD> list)
        {
            try
            {
                foreach (var item in list)
                {
                    PlanoPessoaJuridicaRPO.Cadastrar(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AlterarPlanoPessoaJuridica(List<PlanoPessoaJuridicaMOD> lisPlanoPessoaJuridicaMOD)
        {
            foreach (var item in lisPlanoPessoaJuridicaMOD)
            {
                PlanoPessoaJuridicaRPO.Alterar(item);
            }
        }
    }
}
