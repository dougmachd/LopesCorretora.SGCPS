using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;

namespace LopesCorretora.SGCPS.Business
{
    public class PlanoPessoaJuridicaBUS
    {
        public static void CadastrarPlanoPessoaJuridica(List<PlanoPessoaJuridicaMOD> list, 
            List<int> NumeroDeBeneficiarios = null, List<int> PlanoId = null)
        {
            try
            {
                if (NumeroDeBeneficiarios != null)
                {
                    BindPlanoPessoaJuridica(list, NumeroDeBeneficiarios, PlanoId);
                }

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

        public static List<PlanoPessoaJuridicaMOD> BindPlanoPessoaJuridica(List<PlanoPessoaJuridicaMOD> list,
            List<int> NumeroDeBeneficiarios, List<int> PlanoId)
        {
            try
            {
                for (int i = 0; i < NumeroDeBeneficiarios.Count; i++)
                {
                    list.Add(new PlanoPessoaJuridicaMOD
                    {
                        PlanoId = PlanoId[i],
                        NumeroDeBeneficiarios = NumeroDeBeneficiarios[i],
                        NumeroContrato = list[0].NumeroContrato,
                        NumeroDeParcelas = list[0].NumeroDeParcelas,
                        Observacoes = list[0].Observacoes,
                        Odontologia = list[0].Odontologia,
                        Participacao = list[0].Participacao,
                        PessoaJuridica = list[0].PessoaJuridica,
                        PessoaJuridicaId = list[0].PessoaJuridicaId,
                        Plano = list[0].Plano,
                        QualOdonto = list[0].QualOdonto,
                        Tipo = list[0].Tipo,
                        Usuario = list[0].Usuario,
                        UsuarioId = list[0].UsuarioId,
                        ValorDeEntrada = list[0].ValorDeEntrada
                    });
                }
                return list;
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
