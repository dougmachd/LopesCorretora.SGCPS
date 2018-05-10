using System;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;

namespace LopesCorretora.SGCPS.Repository
{
    public class EnderecoRPO
    {
        public static void Alterar(EnderecoMOD enderecoMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    EnderecoMOD ObjEnderecoMOD = context.Enderecos.Where(x => x.Id == enderecoMOD.Id).First();

                    ObjEnderecoMOD.Bairro = enderecoMOD.Bairro;
                    ObjEnderecoMOD.CEP = enderecoMOD.CEP;
                    ObjEnderecoMOD.Cidade = enderecoMOD.Cidade;
                    ObjEnderecoMOD.Complemento = enderecoMOD.Complemento;
                    ObjEnderecoMOD.Numero = enderecoMOD.Numero;
                    ObjEnderecoMOD.Referencia = enderecoMOD.Referencia;
                    ObjEnderecoMOD.Rua = enderecoMOD.Rua;
                    ObjEnderecoMOD.UF = enderecoMOD.UF;

                    context.Enderecos.Update(ObjEnderecoMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void Cadastrar(EnderecoMOD enderecoPessoaFisicaMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.Enderecos.Add(enderecoPessoaFisicaMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
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
    }
}
