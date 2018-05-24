using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;

namespace LopesCorretora.SGCPS.ViewsModels
{
    public class ControleDeDespesasVM
    {
        public HistoricoDeDespesaMOD ObjHistoricoDeDepesaMOD
		{
			get;
			set;
		}

		public List<HistoricoDeDespesaMOD> ListHistoricoDeDespesaMODs
		{
			get;
			set;
		}
    }
}
