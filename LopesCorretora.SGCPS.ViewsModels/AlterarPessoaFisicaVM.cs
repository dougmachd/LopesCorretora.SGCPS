using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;

namespace LopesCorretora.SGCPS.ViewsModels
{
    public class AlterarPessoaFisicaVM
    {
        public PessoaFisicaMOD ObjPessoaFisicaMOD { get; set; }
        public List<PlanoMOD> LisPlanosMOD { get; set; }
        public List<DependentePessoaFisicaMOD> LisDependentePessoaFisicaMOD { get; set; }
        public List<ContatoPessoaFisicaMOD> LisContatoPessoaFisicaMOD { get; set; }
        public List<StatusMOD> LisStatusMOD { get; set; }
        public List<string> LisNumeroDeParcelas { get; set; }
        public List<string> LisEstadoCivil { get; set; }
    }
}
