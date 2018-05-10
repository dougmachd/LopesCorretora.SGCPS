using System.Collections.Generic;
using LopesCorretora.SGCPS.Models.ModelosComplementares;

namespace LopesCorretora.SGCPS.ViewsModels
{
    public class PesquisaClienteVM
    {
        public List<ModelPesquisa> ListModelPesquisa { get; set; }

        public PesquisaClienteVM()
        {
            ListModelPesquisa = new List<ModelPesquisa>();
        }
    }
}
