using System;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;
using LopesCorretora.SGCPS.ViewsModels;

namespace LopesCorretora.SGCPS.Business
{
    public class PlanoBUS
    {
        public static PlanosVM ListarPlanos()
        {
            return new PlanosVM
            {
                ListPlanosMOD = PlanoRPO.Listar()
            };
        }

        public static PlanoMOD CadastrarPlano(PlanoMOD planoMOD)
        {
            try
            {
                PlanoRPO.Cadastrar(planoMOD);
                return planoMOD;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static PlanoMOD RetornarPlano(int Id)
        {
            return PlanoRPO.Consultar(Id);
        }

        public static PlanoMOD Buscar(int id)
        {
            return PlanoRPO.Consultar(id);
        }

        public static void Alterar(PlanoMOD planoMOD)
        {
            try
            {
                PlanoRPO.Alterar(planoMOD);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
