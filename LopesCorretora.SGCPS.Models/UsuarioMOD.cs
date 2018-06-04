using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace LopesCorretora.SGCPS.Models
{
    public class UsuarioMOD
    {
        public ClaimsPrincipal principal;

        #region DataAnnotations
        [Key]
        [Required(ErrorMessage = "* Campo obrigatório")]
        [Display(Name = "ID Usuario", Description = "ID, usuário")]
        #endregion
        public int Id { get; set; }

        #region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Concessionario", Description = "Concessionario, usuário")]
        #endregion
        public string Concessionario { get; set; }

        #region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "CPF", Description = "CPF, usuário")]
        #endregion
        public string CPF { get; set; }

        #region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Nome", Description = "Nome, usuário")]
        #endregion
        public string Nome { get; set; }

        #region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Celular", Description = "Celular, usuário")]
        #endregion
        public string Celular { get; set; }

        #region DataAnnotations
		[Required(ErrorMessage = "* Campo obrigatório")]
		[Display(Name = "Email", Description = "E-mail, usuário")]
        #endregion
        public string Email { get; set; }

        public UsuarioMOD()
        {

        }

        public UsuarioMOD(ClaimsPrincipal principal)
        {
            this.principal = principal;
        }
    }
}
