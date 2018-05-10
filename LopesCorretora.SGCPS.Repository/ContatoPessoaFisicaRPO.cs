using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository.DataAccess;
using System.Linq;

namespace LopesCorretora.SGCPS.Repository
{
    public class ContatoPessoaFisicaRPO
    {
        public static void Alterar(ContatoPessoaFisicaMOD contatoPessoaFisicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.ContatosPessoasFisicas.Update(contatoPessoaFisicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Alterar(List<ContatoPessoaFisicaMOD> ListContatoPessoaFisicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    foreach (var item in ListContatoPessoaFisicaMOD)
                    {
                        ContatoPessoaFisicaMOD ObjContato = context.ContatosPessoasFisicas.Where(x => x.Id == item.Id).First();
                        ObjContato.Contato = item.Contato;
                        context.ContatosPessoasFisicas.Update(ObjContato);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(ContatoPessoaFisicaMOD contatoPessoaFisicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.ContatosPessoasFisicas.Add(contatoPessoaFisicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void Consultar()
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ContatoPessoaFisicaMOD> Listar(int id)
        {
            try
            {
                List<ContatoPessoaFisicaMOD> Contatos;
                using (SGCPSContext context = new SGCPSContext())
                {
                    Contatos = context.ContatosPessoasFisicas.Where(x => x.PessoaFisicaId == id).ToList();
                }
                return Contatos.Count > 0 ? Contatos : null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
