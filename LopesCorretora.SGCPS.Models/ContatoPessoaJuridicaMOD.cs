using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class ContatoPessoaJuridicaMOD
    {
        #region DataAnnotation
        [Key]
        #endregion
        public int Id { get; set; }

        #region DataAnnotations
        [MinLength(10)]
        [MaxLength(12)]
        [Required(ErrorMessage = "* Campo obrigatório")]
        [Display(Name = "Contato", Description = "Número de contato")]
        #endregion
        public string Contato { get; set; }

        public int PessoaJuridicaId { get; set; }

        public PessoaJuridicaMOD PessoaJuridica { get; set; }

        public ContatoPessoaJuridicaMOD(PessoaJuridicaMOD pessoaJuridicaMOD)
        {
            PessoaJuridica = pessoaJuridicaMOD;
        }

        public ContatoPessoaJuridicaMOD()
        {

        }
    }
}
