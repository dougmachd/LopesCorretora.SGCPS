using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Models.ModelosComplementares;
using System.Linq;

namespace LopesCorretora.SGCPS.Repository
{
    public class PessoaJuridicaRPO
    {
        public static void Alterar(PessoaJuridicaMOD pessoaJuridicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    PessoaJuridicaMOD ObjPessoaJuridicaMOD = context.PessoasJuridicas.Where(x => x.Id == pessoaJuridicaMOD.Id).First();

                    ObjPessoaJuridicaMOD.CNPJ = pessoaJuridicaMOD.CNPJ;
                    ObjPessoaJuridicaMOD.Email = pessoaJuridicaMOD.Email;
                    ObjPessoaJuridicaMOD.InscricaoEstadual = pessoaJuridicaMOD.InscricaoEstadual;
                    ObjPessoaJuridicaMOD.RazaoSocial = pessoaJuridicaMOD.RazaoSocial;
                    ObjPessoaJuridicaMOD.StatusId = pessoaJuridicaMOD.StatusId;
                    ObjPessoaJuridicaMOD.DocumentoAnexo = pessoaJuridicaMOD.DocumentoAnexo;

                    EnderecoRPO.Alterar(pessoaJuridicaMOD.Endereco);
                    EnderecoRPO.Alterar(pessoaJuridicaMOD.EnderecoEntrega);

                    context.Update(ObjPessoaJuridicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void Cadastrar(PessoaJuridicaMOD pessoaJuridicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.PessoasJuridicas.Add(pessoaJuridicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static PessoaJuridicaMOD Consultar(int Id)
        {
            try
            {
                PessoaJuridicaMOD pessoaJuridicaMOD;
                using (SGCPSContext context = new SGCPSContext())
                {
                    var a = from pj in context.PessoasJuridicas
                            join e in context.Enderecos on pj.EnderecoId equals e.Id
                            join ee in context.Enderecos on pj.EnderecoEntregaId equals ee.Id
                            where pj.Id == Id
                            select new PessoaJuridicaMOD
                            {
                                Id = pj.Id,
                                CNPJ = pj.CNPJ,
                                Email = pj.Email,
                                EnderecoEntregaId = pj.EnderecoEntregaId,
                                EnderecoId = pj.EnderecoId,
                                InscricaoEstadual = pj.InscricaoEstadual,
                                RazaoSocial = pj.RazaoSocial,
                                StatusId = pj.StatusId,
                                EnderecoEntrega = new EnderecoMOD
                                {
                                    Id = ee.Id,
                                    Bairro = ee.Bairro,
                                    CEP = ee.CEP,
                                    Cidade = ee.Cidade,
                                    Complemento = ee.Complemento,
                                    Numero = ee.Numero,
                                    Referencia = ee.Referencia,
                                    Rua = ee.Rua,
                                    UF = ee.UF
                                },
                                Endereco = new EnderecoMOD
                                {
                                    Id = e.Id,
                                    Bairro = e.Bairro,
                                    CEP = e.CEP,
                                    Cidade = e.Cidade,
                                    Complemento = e.Complemento,
                                    Numero = e.Numero,
                                    Referencia = e.Referencia,
                                    Rua = e.Rua,
                                    UF = e.UF
                                }
                            };
                    pessoaJuridicaMOD = a.First();
                }
                return pessoaJuridicaMOD;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static List<ModelPesquisa> Pesquisa(string q)
        {
            try
            {
                IEnumerable<ModelPesquisa> ListPessoaJuridicas;
                List<ModelPesquisa> list = new List<ModelPesquisa>();
                using (SGCPSContext context = new SGCPSContext())
                {
                    ListPessoaJuridicas = from pj in context.PessoasJuridicas
                                          join ppj in context.PlanosPessoasJuridicas on pj.Id equals ppj.PessoaJuridica.Id
                                          where pj.RazaoSocial.ToString().ToLower().Contains(q.ToString().ToLower()) ||
                                          ppj.NumeroContrato.ToString().Equals(q.ToString()) ||
                                          pj.CNPJ.ToString().ToLower().Equals(q.ToString().ToLower()) ||
                                          ppj.Observacoes.ToString().ToLower().Contains(q.ToString().ToLower())
                                          select new ModelPesquisa
                                          {
                                              Nome = pj.RazaoSocial,
                                              Documento = pj.CNPJ,
                                              Observacoes = ppj.Observacoes,
                                              NumeroContrato = ppj.NumeroContrato,
                                              Id = pj.Id,
                                              Tipo = "PessoaJuridica",
                                              DocumentoAnexo = pj.DocumentoAnexo
                                          };

                    foreach (var item in ListPessoaJuridicas)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
