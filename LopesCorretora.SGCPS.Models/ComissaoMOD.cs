using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
	public class ComissaoMOD
	{
		#region DataAnnotations
		[Key]
		#endregion
		public int Id { get; set; }

		[Required]
		public int PlanoId { get; set; }

		public PlanoMOD Plano { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Número Da Parcela", Description = "Número Da Parcela")]
		#endregion
		public int NumeroDaParcela { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Percentagem da Comissão", Description = "Percentagem da Comissão")]
		#endregion
		public int Comissao { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Tipo", Description = "Tipo")]
		#endregion
		public string Tipo { get; set; }

	}
}
