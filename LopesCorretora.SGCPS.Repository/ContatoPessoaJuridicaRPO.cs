using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository.DataAccess;
using System.Linq;

namespace LopesCorretora.SGCPS.Repository
{
    public class ContatoPessoaJuridicaRPO
    {
        public static void Alterar(ContatoPessoaJuridicaMOD contatoPessoaJuridicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    ContatoPessoaJuridicaMOD ObjContatoPessoaJuridicaMOD =
                        context.ContatosPessoasJuridicas.Where(x => x.Id == contatoPessoaJuridicaMOD.Id).First();

                    ObjContatoPessoaJuridicaMOD.Contato = contatoPessoaJuridicaMOD.Contato;
                    context.ContatosPessoasJuridicas.Update(ObjContatoPessoaJuridicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Alterar(List<ContatoPessoaJuridicaMOD> ListContatoPessoaJuridicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    foreach (var item in ListContatoPessoaJuridicaMOD)
                    {
                        ContatoPessoaJuridicaMOD ObjContato = context.ContatosPessoasJuridicas.Where(x => x.Id == item.Id).First();
                        ObjContato.Contato = item.Contato;
                        context.ContatosPessoasJuridicas.Update(ObjContato);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(ContatoPessoaJuridicaMOD contatoPessoaJuridicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.ContatosPessoasJuridicas.Add(contatoPessoaJuridicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static ContatoPessoaJuridicaMOD Consultar(int id)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    return context.ContatosPessoasJuridicas.Where(x => x.Id == id).First();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<ContatoPessoaJuridicaMOD> Listar(int id)
        {
            try
            {
                List<ContatoPessoaJuridicaMOD> Contatos;
                using (SGCPSContext context = new SGCPSContext())
                {
                    Contatos = context.ContatosPessoasJuridicas.Where(x => x.PessoaJuridicaId == id).ToList();
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
