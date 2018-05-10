using System;
using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class DependentePessoaFisicaMOD
    {
        #region DataAnnotation
        [Key]
        #endregion
        public int Id { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage ="Campo obrigatorio")]
        [Display(Name ="Nome", Description ="Nome do dependente, pessoa fisica")]
        #endregion
        public string Nome { get; set; }

        #region DataAnnotations
        [Display(Name ="CPF", Description = "CPF do dependente, pessoa fisica")]
        #endregion
        public string CPF { get; set; }
        
        #region DataAnnotations
        [Display(Name ="RG", Description = "RG do dependente, pessoa fisica")]
        #endregion
        public string RG { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Data de nascimento", Description = "Data de nascimento do dependente, pessoa fisica")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        #endregion
        public DateTime? DataDeNascimento { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Grau de parentesco", Description = "Grau de parentesco do dependente, pessoa fisica")]
        #endregion
        public string GrauDeParentesco { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage ="Campo obrigatorio")]
        [Display(Name = "Nome da mae", Description = "Nome da mae do dependente, pessoa fisica")]
        #endregion
        public string NomeDaMae { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Estado civil", Description = "Estado civil do dependente, pessoa fisica")]
        #endregion
        public string EstadoCivil { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Numero do SUS", Description = "Numero do SUS do dependente, pessoa fisica")]
        #endregion
        public string NumeroDoSUS { get; set; }

        [Required]
        public int PessoaFisicaId { get; set; }

        public PessoaFisicaMOD PessoaFisica { get; set; }

        public DependentePessoaFisicaMOD(PessoaFisicaMOD pessoaFisicaMOD)
        {
            PessoaFisica = pessoaFisicaMOD;
        }

        public DependentePessoaFisicaMOD()
        {

        }
    }
}
