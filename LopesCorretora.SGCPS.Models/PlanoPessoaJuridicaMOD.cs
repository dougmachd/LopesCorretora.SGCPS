using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class PlanoPessoaJuridicaMOD
    {
        #region DataAnnotations
        [Key]
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "ID Plano Pessoa Juridica", Description = "ID Plano, pessoa juridica")]
        #endregion
        public int Id { get; set; }

        public bool Participacao { get; set; }

        public bool Odontologia { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Numero do Contrato", Description = "Numero do Contrato, pessoa juridica")]
        #endregion
        public string NumeroContrato { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Valor de Entrada", Description = "Valor de Entrada, pessoa juridica")]
        #endregion
        public decimal? ValorDeEntrada { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Numero de Parcelas", Description = "Numero de Parcelas, pessoa juridica")]
        #endregion
        public int? NumeroDeParcelas { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Numero De Beneficiarios", Description = "Numero Do Beneficiarios, pessoa juridica")]
        #endregion
        public int? NumeroDeBeneficiarios { get; set; }

        public string Observacoes { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Participacao", Description = "Participacao, pessoa juridica")]
        #endregion
        public string StrParticipacao { get => Participacao == true? "Com Participacao" : "Sem Participacao" ; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Odontologia", Description = "Odontologia, pessoa juridica")]
        #endregion
        public string StrOdontologia { get => Odontologia == true ? "Com Odontologia" : "Sem Odontologia"; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
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

        public PlanoPessoaJuridicaMOD()
        {
            //Plano = new PlanoMOD();
            //Usuario = new UsuarioMOD();
            //PessoaJuridica = new PessoaJuridicaMOD();
        }
    }
}
