using System;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository.DataAccess;

namespace LopesCorretora.SGCPS.Repository
{
    public class PlanoPessoaFisicaRPO
    {
        public static void Alterar(PlanoPessoaFisicaMOD planoPessoaFisicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.PlanoPessoasFisicas.Update(planoPessoaFisicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Cadastrar(PlanoPessoaFisicaMOD planoPessoaFisicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.PlanoPessoasFisicas.Add(planoPessoaFisicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Consultar()
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
