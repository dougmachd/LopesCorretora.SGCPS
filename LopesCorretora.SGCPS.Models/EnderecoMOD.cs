using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class EnderecoMOD
    {
        #region DataAnnotation
        [Key]
        #endregion
        public int Id { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name ="UF",Description ="Estado, pessoa física")]
        #endregion
        public string UF { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name ="Cidade", Description = "Cidade, pessoa física")]
        #endregion
        public string Cidade { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name ="Bairro",Description = "Nome do Bairro, pessoa física")]
        #endregion
        public string Bairro { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name ="Rua",Description = "Nome da Rua. Pessoa física")]
        #endregion
        public string Rua { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name ="Número",Description = "Numero endereco, pessoa física")]
        #endregion
        public int? Numero { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name ="Complemento",Description = "Complemento do endereco. Pessoa física")]
        #endregion
        public string Complemento { get; set; }

        #region DataAnnotations
		[Display(Name = "Referencia", Description = "Ponto de Referencia do endereco. Pessoa física")]
        #endregion
        public string Referencia { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name ="CEP",Description = "CEP, pessoa física")]
        #endregion
        public string CEP { get; set; }
    }
}
