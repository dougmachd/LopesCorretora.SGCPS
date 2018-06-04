using System;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;
using System.Collections.Generic;

namespace LopesCorretora.SGCPS.Repository
{
    public class ComissaoRPO
    {
        public static void Alterar(ComissaoMOD comissaoMOD)
        {
            try
            {
                using (SGCPSContext contex = new SGCPSContext())
                {
                    ComissaoMOD ObjComissaoMOD = contex.Comissoes.Where(x => x.Id == comissaoMOD.Id).First();
                    ObjComissaoMOD.NumeroDaParcela = comissaoMOD.NumeroDaParcela;
                    ObjComissaoMOD.PlanoId = comissaoMOD.PlanoId;
                    ObjComissaoMOD.Comissao = comissaoMOD.Comissao;
                    ObjComissaoMOD.Tipo = comissaoMOD.Tipo;
                    contex.Comissoes.Update(ObjComissaoMOD);
                    contex.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(ComissaoMOD comissaoMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.Comissoes.Add(comissaoMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(List<ComissaoMOD> ListComissaoMODs)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    foreach (var item in ListComissaoMODs)
                    {
                        if (!Exists(item))
                        {
                            context.Comissoes.Add(item);
                        }
                        else
                        {
                            AlterarPorParcela(item);
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static bool Exists(ComissaoMOD comissaoMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    if (context.Comissoes.Where(x => x.NumeroDaParcela == comissaoMOD.NumeroDaParcela
                        && x.PlanoId == comissaoMOD.PlanoId).First() != null)
                    {
                        return true;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                if (e.Message.Equals("Sequence contains no elements"))
                    return false;
                throw;
            }
        }

        public static ComissaoMOD Consultar(int PlanoId, int NumeroDaParcela, string Tipo)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    return context.Comissoes.Where(x => x.PlanoId == PlanoId && x.NumeroDaParcela == NumeroDaParcela
                                                    && x.Tipo.Equals(Tipo)).First();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<ComissaoMOD> Consultar(int PlanoId)
        {
            try
            {
                List<ComissaoMOD> ListComissaoMODs = new List<ComissaoMOD>();
                using (SGCPSContext context = new SGCPSContext())
                {
                    ComissaoMOD comissaoMOD = context.Comissoes.Where(x => x.PlanoId == PlanoId && x.Tipo.Equals("PME de 03 até 29 vidas")).FirstOrDefault();
                    if (comissaoMOD != null)
                        ListComissaoMODs.Add(comissaoMOD);

                    comissaoMOD = context.Comissoes.Where(x => x.PlanoId == PlanoId && x.Tipo.Equals("PME de 30 até 99 vidas")).FirstOrDefault();
                    if (comissaoMOD != null)
                        ListComissaoMODs.Add(comissaoMOD);

                    comissaoMOD = context.Comissoes.Where(x => x.PlanoId == PlanoId && x.Tipo.Equals("PME")).FirstOrDefault();
                    if (comissaoMOD != null)
                        ListComissaoMODs.Add(comissaoMOD);
                }
                return ListComissaoMODs;
            }
            catch (Exception e)
            {
                return new List<ComissaoMOD>();
            }
        }

        public static List<ComissaoMOD> Listar(int PlanoId, string Tipo)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    return context.Comissoes.Where(x => x.PlanoId.Equals(PlanoId) && x.Tipo.Equals(Tipo)).ToList();
                }
            }
            catch (Exception e)
            {
                return new List<ComissaoMOD>();
            }
        }

        private static void AlterarPorParcela(ComissaoMOD comissaoMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    ComissaoMOD ObjComissaoMOD = context.Comissoes.Where(x => x.NumeroDaParcela == comissaoMOD.NumeroDaParcela && x.PlanoId == comissaoMOD.PlanoId).First();
                    ObjComissaoMOD.NumeroDaParcela = comissaoMOD.NumeroDaParcela;
                    ObjComissaoMOD.PlanoId = comissaoMOD.PlanoId;
                    ObjComissaoMOD.Comissao = comissaoMOD.Comissao;
                    ObjComissaoMOD.Tipo = comissaoMOD.Tipo;
                    context.Comissoes.Update(ObjComissaoMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
