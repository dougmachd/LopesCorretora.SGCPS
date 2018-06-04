using System;
using LopesCorretora.SGCPS.ViewsModels;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;
using LopesCorretora.SGCPS.Business;
using System.Collections.Generic;

namespace LopesCorretora.SGCPS.Business
{
    public class ComissaoBUS
    {
        public static void Cadastrar(ComissaoVM comissaoVM)
        {
            try
            {
                ComissaoRPO.Cadastrar(comissaoVM.ObjComissaoMOD);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(int PlanoId, List<string> Tipos, List<int> NumeroDaParcela, List<int> Comissao)
        {
            try
            {
                ComissaoRPO.Cadastrar(BuildComissao(PlanoId, Tipos, NumeroDaParcela, Comissao));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static List<ComissaoMOD> BuildComissao(int PlanoId, List<string> Tipos, List<int> NumeroDaParcela, List<int> Comissao)
        {
            List<ComissaoMOD> ListComissaoMODs = new List<ComissaoMOD>();
            for (int i = 0; i < Comissao.Count; i++)
            {
                ListComissaoMODs.Add(new ComissaoMOD
                {
                    Comissao = Comissao[i],
                    NumeroDaParcela = NumeroDaParcela[i],
                    Tipo = Tipos[i],
                    PlanoId = PlanoId
                });
            }
            return ListComissaoMODs;
        }

        public static ComissaoVM ComissaoVM(ComissaoMOD comissaoMOD = null)
        {
            try
            {
                return new ComissaoVM
                {
                    LisPlanosMOD = PlanoRPO.Listar(),
                    ObjComissaoMOD = comissaoMOD
                };
            }
            catch (Exception)
            {
                return new ComissaoVM
                {
                    LisPlanosMOD = new List<PlanoMOD>(),
                    ObjComissaoMOD = comissaoMOD
                };
            }
        }

        public static List<ComissaoMOD> ReturnTipos(int id)
        {
            return ComissaoRPO.Consultar(id);
        }
    }
}
