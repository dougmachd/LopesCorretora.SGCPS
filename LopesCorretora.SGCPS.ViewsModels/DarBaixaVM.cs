using System;
using System.Collections.Generic;
using System.Text;
using LopesCorretora.SGCPS.Models;

namespace LopesCorretora.SGCPS.ViewsModels
{
    public class DarBaixaVM
    {
		public List<ComissaoMOD> ListComissaoMODs
		{
			get;
			set;
		}

		public List<HistoricoDeRecebimentoPfMOD> ListHistoricoDeRecebimentoPfMODs
		{
			get;
			set;
		}

		public List<HistoricoDeRecebimentoPjMOD> ListHistoricoDeRecebimentoPjMODs
        {
            get;
            set;
        }

		public PessoaFisicaMOD ObjPessoaFisicaMOD
		{
			get;
			set;
		}

		public PlanoPessoaJuridicaMOD ObjPlanoPessoaJuridicaMOD
        {
            get;
            set;
        }

		public HistoricoDeRecebimentoPjMOD ObjHistoricoDeRecebimentoPjMOD
		{
			get;
			set;
		}

		public HistoricoDeRecebimentoPfMOD ObjHistoricoDeRecebimentoPfMOD
		{
			get;
			set;
		}
    }
}
