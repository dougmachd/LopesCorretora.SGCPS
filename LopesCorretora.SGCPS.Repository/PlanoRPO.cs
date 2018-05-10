using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;

namespace LopesCorretora.SGCPS.Repository
{
    public class PlanoRPO
    {
        public static void Alterar(PlanoMOD planoMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    PlanoMOD ObjPlanoMOD = context.Planos.Where(x => x.Id == planoMOD.Id).First();
                    ObjPlanoMOD.Plano = planoMOD.Plano;
                    ObjPlanoMOD.TelefoneDoPlano = planoMOD.TelefoneDoPlano;
                    context.Planos.Update(ObjPlanoMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(PlanoMOD planoMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.Planos.Add(planoMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static PlanoMOD Consultar(int Id)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    return context.Planos.Where(x => x.Id == Id).First();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static List<PlanoMOD> Listar()
        {
            try
            {
                List<PlanoMOD> Planos;
                using (SGCPSContext context = new SGCPSContext())
                {
                    Planos = context.Planos.ToList();
                }
                return Planos.Count > 0 ? Planos : null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
