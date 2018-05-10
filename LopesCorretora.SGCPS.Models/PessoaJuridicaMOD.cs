﻿using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class PessoaJuridicaMOD
    {
        #region DataAnnotations
        [Key]
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "ID Pessoa Juridica", Description = "Titular, pessoa fisica")]
        #endregion
        public int Id { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Razao Social", Description = "Titular, pessoa fisica")]
        #endregion
        public string RazaoSocial { get; set; }

        #region DataAnnotations
        [MaxLength(14, ErrorMessage ="Tamanho maximo: 14 caracteres")]
        [MinLength(14, ErrorMessage = "Tamanho minimo: 14 caracteres")]
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "CNPJ", Description = "Titular, pessoa fisica")]
        #endregion
        public string CNPJ { get; set; }

        #region DataAnnotations
        [MinLength(12, ErrorMessage = "Tamanho minimo: 12 caracteres")]
        [MaxLength(12, ErrorMessage = "Tamanho maximo: 12 caracteres")]
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Inscricao Estadual", Description = "Titular, pessoa fisica")]
        #endregion
        public string InscricaoEstadual { get; set; }

        #region DataAnnotations
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "E-mail", Description = "E-mail, pessoa fisica")]
        #endregion
        public string Email { get; set; }

        public int EnderecoId { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Endereco PJ", Description = "Titular, pessoa fisica")]
        #endregion
        public EnderecoMOD Endereco { get; set; }

        public int EnderecoEntregaId { get; set; }

        #region DataAnnotations
        //[Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Documentos (anexo)", Description = "Documentos (anexo), pessoa fisica")]
        #endregion
        public string DocumentoAnexo { get; set; }

        #region DataAnnotations
        [Required(ErrorMessage = "* Campo obrigatorio")]
        [Display(Name = "Endereco de Entrega", Description = "Titular, pessoa fisica")]
        #endregion
        public EnderecoMOD EnderecoEntrega { get; set; }

        [Required]
        public int StatusId { get; set; }

        public StatusMOD Status { get; set; }

        public PessoaJuridicaMOD()
        {
            EnderecoEntrega = new EnderecoMOD();
            Endereco = new EnderecoMOD();
        }
    }
}
