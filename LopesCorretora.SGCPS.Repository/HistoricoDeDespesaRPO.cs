using System;
using System.Collections.Generic;
using System.Linq;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository.DataAccess;

namespace LopesCorretora.SGCPS.Repository
{
	public class HistoricoDeDespesaRPO
	{

		public static List<HistoricoDeDespesaMOD> Consultar(DateTime inicio, DateTime fim)
		{
			try
			{
                List<HistoricoDeDespesaMOD> ListHistoricoDeDespesaMODs = new List<HistoricoDeDespesaMOD>();
                using (SGCPSContext context = new SGCPSContext())
				{
                    ListHistoricoDeDespesaMODs = context.HistoricoDeDespesas.Where(x => x.DataDaBaixa >= inicio && x.DataDaBaixa <= fim).ToList();
				}
                return ListHistoricoDeDespesaMODs != null ? ListHistoricoDeDespesaMODs : new List<HistoricoDeDespesaMOD>();
            }
			catch (Exception e)
			{
				return new List<HistoricoDeDespesaMOD>();
			}
		}

		public static void Cadastrar(HistoricoDeDespesaMOD historicoDeDespesaMOD)
		{
			try
			{
				using (SGCPSContext context = new SGCPSContext())
				{
					context.HistoricoDeDespesas.Add(historicoDeDespesaMOD);
					context.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static void Cadastrar(List<HistoricoDeDespesaMOD> listHistoricoDeDespesaMODs)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
					foreach (var item in listHistoricoDeDespesaMODs)
					{
						context.HistoricoDeDespesas.Add(item);
                    }
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
