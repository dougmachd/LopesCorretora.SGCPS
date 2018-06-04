using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;

namespace LopesCorretora.SGCPS.ViewsModels
{
    public class CadastrarPessoaJuridicaVM
    {
        public PessoaJuridicaMOD ObjPessoaJuridicaMOD { get; set; }
        public List<PlanoPessoaJuridicaMOD> ListPlanoPessoaJuridicaMODs { get; set; }
        public List<ContatoPessoaJuridicaMOD> LisContatoPessoaJuridicaMODs { get; set; }
        public List<PlanoMOD> LisPlanoMODs { get; set; }
        public List<StatusMOD> ListStatusMODs { get; set; }
        public List<ComissaoMOD> ListComissaoMODs { get; set; }
    }
}
