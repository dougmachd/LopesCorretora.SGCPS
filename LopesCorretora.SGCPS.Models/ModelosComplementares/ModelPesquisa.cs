using System;
using System.Collections.Generic;
using System.Text;

namespace LopesCorretora.SGCPS.Models.ModelosComplementares
{
    public class ModelPesquisa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroContrato { get; set; }
        public string Observacoes { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }
        public string DocumentoAnexo { get; set; }



        public ModelPesquisa(string Nome, string NumeroContrato, string Observacoes, string Documento)
        {
            this.Nome = Nome;
            this.NumeroContrato = NumeroContrato;
            this.Observacoes = Observacoes;
            this.Documento = Documento;
        }
        public ModelPesquisa()
        {

        }
    }
}
