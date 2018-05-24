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

        //public static void Listar(int id)
        //{
        //    ComissaoRPO.Listar(id);
        //}
    }
}
