using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;

namespace LopesCorretora.SGCPS.Repository
{
    public class PlanoPessoaJuridicaRPO
    {
        public static void Alterar(PlanoPessoaJuridicaMOD planoPessoaJuridicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    PlanoPessoaJuridicaMOD ObjPlanoPessoaJuridicaMOD =
                        context.PlanosPessoasJuridicas.Where(x => x.Id == planoPessoaJuridicaMOD.Id).First();

                    ObjPlanoPessoaJuridicaMOD.NumeroContrato = planoPessoaJuridicaMOD.NumeroContrato;
                    ObjPlanoPessoaJuridicaMOD.NumeroDeBeneficiarios = planoPessoaJuridicaMOD.NumeroDeBeneficiarios;
                    ObjPlanoPessoaJuridicaMOD.NumeroDeParcelas = planoPessoaJuridicaMOD.NumeroDeParcelas;
                    ObjPlanoPessoaJuridicaMOD.Observacoes = planoPessoaJuridicaMOD.Observacoes;
                    ObjPlanoPessoaJuridicaMOD.Odontologia = planoPessoaJuridicaMOD.Odontologia;
                    ObjPlanoPessoaJuridicaMOD.Participacao = planoPessoaJuridicaMOD.Participacao;
                    ObjPlanoPessoaJuridicaMOD.PlanoId = planoPessoaJuridicaMOD.PlanoId;
                    ObjPlanoPessoaJuridicaMOD.QualOdonto = planoPessoaJuridicaMOD.QualOdonto;
                    ObjPlanoPessoaJuridicaMOD.UsuarioId = planoPessoaJuridicaMOD.UsuarioId;

                    context.PlanosPessoasJuridicas.Update(ObjPlanoPessoaJuridicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void Cadastrar(PlanoPessoaJuridicaMOD planoPessoaJuridicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.PlanosPessoasJuridicas.Add(planoPessoaJuridicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static PlanoPessoaJuridicaMOD Consultar(int Id)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    return context.PlanosPessoasJuridicas.Where(x => x.Id == Id).First();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<PlanoPessoaJuridicaMOD> Listar(int id)
        {
            try
            {
                List<PlanoPessoaJuridicaMOD> Lista;
                using (SGCPSContext context = new SGCPSContext())
                {
                    Lista = context.PlanosPessoasJuridicas.Where(x => x.PessoaJuridicaId == id).ToList();
                }
                return Lista.Count > 0 ? Lista : null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
