using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class ContatoPessoaFisicaMOD
    {
        #region DataAnnotation
        [Key]
        #endregion
        public int Id { get; set; }

        #region DataAnnotations
        [MinLength(10)]
        [MaxLength(12)]
        [Required(ErrorMessage ="Campo obrigatorio")]
        [Display(Name ="Contato", Description ="Numero de contato")]
        #endregion
        public string Contato { get; set; }

        [Required]
        public int PessoaFisicaId { get; set; }

        public PessoaFisicaMOD PessoaFisica { get; set; }

        public ContatoPessoaFisicaMOD(PessoaFisicaMOD pessoaFisicaMOD)
        {
            PessoaFisica = pessoaFisicaMOD;
        }

        public ContatoPessoaFisicaMOD()
        {

        }
    }
}
