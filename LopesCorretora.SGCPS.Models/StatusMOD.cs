using System.ComponentModel.DataAnnotations;

namespace LopesCorretora.SGCPS.Models
{
    public class StatusMOD
    {
        #region DataAnnotations
        [Key]
        [Required(ErrorMessage ="* Campo obrigatorio")]
        #endregion
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
