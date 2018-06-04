using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class PlanoPessoaFisicaMOD
    {
        #region DataAnnotation
        [Key]
        #endregion
        public int Id { get; set; }

        #region DataAnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
        [Display(Name = "Número do contrado", Description = "Número de contrato, plano pessoa física")]
        #endregion
        public string NumeroContrato { get; set; }

        #region DataAnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Valor de entrada", Description = "Valor de entrada do plano, pessoa física")]
        #endregion
        public decimal? ValorDeEntrada { get; set; }

        #region DataAnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Número de parcelas", Description = "Número de parcelas do plano, pessoa física")]
        #endregion
        public int? NumeroDeParcelas { get; set; }

        public int PlanoId { get; set; }

        public PlanoMOD Plano { get; set; }
    }
}
