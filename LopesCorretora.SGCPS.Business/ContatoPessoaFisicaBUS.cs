using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;

namespace LopesCorretora.SGCPS.Business
{
    public class ContatoPessoaFisicaBUS
    {
        public static void CadastrarContatosPessoaJuridica(List<ContatoPessoaJuridicaMOD> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ContatoPessoaJuridicaRPO.Cadastrar(item);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
