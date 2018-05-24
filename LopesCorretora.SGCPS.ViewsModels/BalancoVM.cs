using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using LopesCorretora.SGCPS.Models;

namespace LopesCorretora.SGCPS.ViewsModels
{
    public class BalancoVM
    {
        public List<HistoricoDeRecebimentoPfMOD> ListHistoricoDeRecebimentoPfMODs { get; set; }
        public List<HistoricoDeRecebimentoPjMOD> ListHistoricoDeRecebimentoPjMODs { get; set; }
        public List<HistoricoDeDespesaMOD> ListHistoricoDeDespesaMODs { get; set; }

        [Range(0.0, Double.MaxValue)]
        public decimal TotalEntrada
        {
            get => ListHistoricoDeRecebimentoPfMODs.Sum(x => x.ValorComissao) +
                                                   ListHistoricoDeRecebimentoPjMODs.Sum(x => x.ValorComissao);
        }

        [Range(0.0, Double.MaxValue)]
        public decimal TotalSaida { get => ListHistoricoDeDespesaMODs.Sum(x => x.Valor); }

        [Range(0.0, Double.MaxValue)]
        public decimal DiferencaNoPeriodo { get => (TotalEntrada - TotalSaida); }

        [Range(0.0, Double.MaxValue)]
        public decimal PercentagemEntrada { get => DiferencaNoPeriodo > 0 ? 100 : (TotalEntrada / (TotalSaida / 100)); }

        [Range(0.0, Double.MaxValue)]
        public decimal PercentagemSaida { get => DiferencaNoPeriodo < 0 ? 100 : (TotalSaida / (TotalEntrada / 100)); }

        [Range(0.0, Double.MaxValue)]
        public decimal PercentagemDiferenca { get => DiferencaNoPeriodo > 0 ? PercentagemEntrada - PercentagemSaida : PercentagemSaida - PercentagemEntrada; }
    }
}
