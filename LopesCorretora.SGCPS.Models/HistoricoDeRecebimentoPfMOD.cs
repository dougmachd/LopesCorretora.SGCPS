using System;
using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
	public class HistoricoDeRecebimentoPfMOD
	{
		[Key]
		public int Id
		{
			get;
			set;
		}

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Número da parcela", Description = "Número da parcela")]
		#endregion
		public int NumeroDaParcela
		{
			get;
			set;
		}


		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Comissão", Description = "Comissão")]
		#endregion
		public decimal Comissao
		{
			get;
			set;
		}

		public PessoaFisicaMOD PessoaFisica
		{
			get;
			set;
		}

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Pessoa Física", Description = "Pessoa Física")]
		#endregion
		public int PessoaFisicaId
		{
			get;
			set;
		}

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Data da baixa", Description = "Data da baixa")]
		#endregion
		public DateTime DataDaBaixa
		{
			get;
			set;
		}

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Número Do Contrato", Description = "Número Do Contrato")]
		#endregion
		public string NumeroDoContrato
		{
			get;
			set;
		}

		public decimal ValorDeEntrada { get; set; }

		public decimal ValorComissao { get => (ValorDeEntrada / 100) * Comissao; }
	}
}
