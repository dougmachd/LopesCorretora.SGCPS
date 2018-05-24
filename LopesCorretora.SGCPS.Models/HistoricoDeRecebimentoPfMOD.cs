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
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Numero da parcela", Description = "Numero da parcela")]
		#endregion
		public int NumeroDaParcela
		{
			get;
			set;
		}


		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatorio")]
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
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Pessoa Juridica", Description = "Pessoa Juridica")]
		#endregion
		public int PessoaFisicaId
		{
			get;
			set;
		}

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Data da baixa", Description = "Data da baixa")]
		#endregion
		public DateTime DataDaBaixa
		{
			get;
			set;
		}

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Numero Do Contrato", Description = "Numero Do Contrato")]
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
