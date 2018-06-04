using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
	public class PlanoPessoaJuridicaMOD
	{
		#region DataAnnotations
		[Key]
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "ID Plano Pessoa Juridica", Description = "ID Plano, pessoa jurídica")]
		#endregion
		public int Id { get; set; }

		public bool Participacao { get; set; }

		public bool Odontologia { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Numero do Contrato", Description = "Número do Contrato, pessoa jurídica")]
		#endregion
		public string NumeroContrato { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Valor de Entrada", Description = "Valor de Entrada, pessoa jurídica")]
		#endregion
		public decimal? ValorDeEntrada { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Numero de Parcelas", Description = "Número de Parcelas, pessoa jurídica")]
		#endregion
		public int? NumeroDeParcelas { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Numero De Beneficiarios", Description = "Número Do Beneficiarios, pessoa jurídica")]
		#endregion
		public int? NumeroDeBeneficiarios { get; set; }

		public string Observacoes { get; set; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Participação", Description = "Participacao, pessoa jurídica")]
		#endregion
		public string StrParticipacao { get => Participacao == true ? "Com Participacao" : "Sem Participacao"; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Odontologia", Description = "Odontologia, pessoa juridica")]
		#endregion
		public string StrOdontologia { get => Odontologia == true ? "Com Odontologia" : "Sem Odontologia"; }

		#region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Qual Odonto", Description = "Qual plano odontologico?")]
		#endregion
		public string QualOdonto { get; set; }

		[Required]
		public int PlanoId { get; set; }

		public PlanoMOD Plano { get; set; }

		[Required]
		public int UsuarioId { get; set; }

		public UsuarioMOD Usuario { get; set; }

		[Required]
		public int PessoaJuridicaId { get; set; }

		public PessoaJuridicaMOD PessoaJuridica { get; set; }

		#region DataAnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
        [Display(Name = "Tipo", Description = "Tipo do plano")]
        #endregion
		public string Tipo { get; set; }

        #region DataAnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
        [Display(Name = "Categoria", Description = "Categoria do plano")]
        #endregion
        public string  Categoria { get; set; }
    }
}
