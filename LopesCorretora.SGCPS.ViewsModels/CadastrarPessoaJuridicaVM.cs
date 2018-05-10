using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;

namespace LopesCorretora.SGCPS.ViewsModels
{
    public class CadastrarPessoaJuridicaVM
    {
        //migration
        public PessoaJuridicaMOD ObjPessoaJuridicaMOD { get; set; }
        public List<PlanoPessoaJuridicaMOD> ListPlanoPessoaJuridicaMOD { get; set; }
        public List<ContatoPessoaJuridicaMOD> LisContatoPessoaJuridicaMOD { get; set; }


        //public UsuarioMOD ObjUsuarioMOD { get; set; }
        public List<PlanoMOD> LisPlanoMOD { get; set; }
        public List<StatusMOD> ListStatusMOD { get; set; }

    }
}
