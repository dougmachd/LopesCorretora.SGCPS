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
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Numero Da Parcela", Description = "Numero Da Parcela")]
		#endregion
		public int NumeroDaParcela { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Percentagem da Comissao", Description = "Percentagem da Comissao")]
		#endregion
		public int Comissao { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatorio")]
		[Display(Name = "Tipo", Description = "Tipo")]
		#endregion
		public string Tipo { get; set; }

	}
}
