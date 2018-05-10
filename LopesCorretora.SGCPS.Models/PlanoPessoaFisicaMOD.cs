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
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Numero do contrado", Description = "Numero de contrato, plano pessoa fisica")]
        #endregion
        public string NumeroContrato { get; set; }

        #region DataAnotations
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Valor de entrada", Description = "Valor de entrada do plano, pessoa fisica")]
        #endregion
        public decimal? ValorDeEntrada { get; set; }

        #region DataAnotations
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Numero de parcelas", Description = "Numero de parcelas do plano, pessoa fisica")]
        #endregion
        public int? NumeroDeParcelas { get; set; }

        public int PlanoId { get; set; }

        public PlanoMOD Plano { get; set; }
    }
}
