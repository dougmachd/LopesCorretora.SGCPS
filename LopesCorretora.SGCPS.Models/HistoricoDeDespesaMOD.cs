using System;
using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class HistoricoDeDespesaMOD
    {
        #region
        [Key]
        #endregion
        public int Id
        {
            get;
            set;
        }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Descrição", Description = "Descrição da despesa")]
        #endregion
        public string Tipo
        {
            get;
            set;
        }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Valor", Description = "Valor da despesa")]
        #endregion
        public decimal Valor
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
    }
}
