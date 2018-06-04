using System;
using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class HistoricoDeRecebimentoPjMOD
    {
		[Key]
        public int Id
        {
            get;
            set;
        }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Número da parcela", Description = "Número da parcela")]
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

        public PessoaJuridicaMOD PessoaJuridica
        {
            get;
            set;
        }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Pessoa Jurídica", Description = "Pessoa Jurídica")]
        #endregion
        public int PessoaJuridicaId
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
        [Display(Name = "Número Do Contrato", Description = "Número Do Contrato")]
        #endregion
        public string NumeroDoContrato
        {
            get;
            set;
        }

		public decimal ValorDeEntrada { get; set; }

        [Range(0.0, Double.MaxValue)]
        public decimal ValorComissao { get => (ValorDeEntrada / 100) * Comissao; }
    }
}
