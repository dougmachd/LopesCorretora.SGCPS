using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;

namespace LopesCorretora.SGCPS.Business
{
    public class HistoricoDeDespesaBUS
    {

        public HistoricoDeDespesaBUS()
        {
        }

        public static List<HistoricoDeDespesaMOD> HistoricoDeDespesaMensal()
        {
            try
            {
                string inicio = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";
                string fim = DateTime.Now.Year + "-" + DateTime.Now.Month + "-31";
                return HistoricoDeDespesaRPO.Consultar(Convert.ToDateTime(inicio), Convert.ToDateTime(fim));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<HistoricoDeDespesaMOD> HistoricoDeDespesaAnual()
        {
            try
            {
                string inicio = DateTime.Now.Year + "-01-01";
                string fim = DateTime.Now.Year + "-12-31";
                return HistoricoDeDespesaRPO.Consultar(Convert.ToDateTime(inicio), Convert.ToDateTime(fim));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(List<string> Tipos, List<string> Valores, List<string> Datas)
        {
            try
            {
                List<HistoricoDeDespesaMOD> ListHistoricoDeDespesaMOD = new List<HistoricoDeDespesaMOD>();
                for (int i = 0; i < Tipos.Count; i++)
                {
                    ListHistoricoDeDespesaMOD.Add(new HistoricoDeDespesaMOD
                    {
                        Tipo = Tipos[i],
                        Valor = Convert.ToDecimal(Valores[i]),
                        DataDaBaixa = Convert.ToDateTime(Datas[i])
                    });
                };
                HistoricoDeDespesaRPO.Cadastrar(ListHistoricoDeDespesaMOD);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
