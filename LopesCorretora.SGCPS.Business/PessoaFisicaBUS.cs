using System;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;
using LopesCorretora.SGCPS.ViewsModels;

namespace LopesCorretora.SGCPS.Business
{
    public class PessoaFisicaBUS
    {
        #region Action BUS: Cadastrar Pessoa Fisica
        public static CadastrarPessoaFisicaVM CadastrarPessoaFisicaVM()
        {
            try
            {
                return new CadastrarPessoaFisicaVM()
                {
                    ObjPessoaFisicaMOD = new PessoaFisicaMOD(),
                    LisPlanosMOD = PlanoRPO.Listar(),
                    LisStatusMOD = StatusRPO.Listar(),
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void ActionCadastrarPessoaFisica(CadastrarPessoaFisicaVM cadastrarPessoaFisicaVM)
        {
            try
            {
                CadastrarPessoaFisica(cadastrarPessoaFisicaVM);
                CadastrarContatoPessoaFisica(cadastrarPessoaFisicaVM);
                CadastrarDependentePessoaFisica(cadastrarPessoaFisicaVM);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static void CadastrarContatoPessoaFisica(CadastrarPessoaFisicaVM cadastrarPessoaFisicaVM)
        {
            foreach (var contato in cadastrarPessoaFisicaVM.LisContatoPessoaFisicaMOD)
            {
                if (contato.Contato != null)
                {
                    if (!contato.Contato.ToString().Trim().Equals(""))
                    {
                        contato.PessoaFisicaId = cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD.Id;
                        ContatoPessoaFisicaRPO.Cadastrar(contato);
                    }
                }
            }
        }

        private static void CadastrarDependentePessoaFisica(CadastrarPessoaFisicaVM cadastrarPessoaFisicaVM)
        {
            foreach (var dependente in cadastrarPessoaFisicaVM.LisDependentePessoaFisicaMOD)
            {
                if (dependente != null && cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD != null)
                {
                    dependente.PessoaFisicaId = cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD.Id;
                    DependentePessoaFisicaRPO.Cadastrar(dependente);
                }
            }
        }

        private static void CadastrarPessoaFisica(CadastrarPessoaFisicaVM cadastrarPessoaFisicaVM)
        {
            if (cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD != null)
            {
                PessoaFisicaRPO.Cadastrar(cadastrarPessoaFisicaVM.ObjPessoaFisicaMOD);
            }
        }

        public static CadastrarPessoaFisicaVM PopularVM(PessoaFisicaMOD pessoaFisicaMOD)
        {
            try
            {
                return new CadastrarPessoaFisicaVM()
                {
                    ObjPessoaFisicaMOD = pessoaFisicaMOD,
                    LisPlanosMOD = PlanoRPO.Listar(),
                    LisStatusMOD = StatusRPO.Listar(),
                };
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region Action BUS: Alterar Pessoa Fisica
        public static AlterarPessoaFisicaVM AlterarPessoaFisicaVM(int id)
        {
            try
            {
                AlterarPessoaFisicaVM alterarPessoaFisicaVM = new AlterarPessoaFisicaVM()
                {
                    ObjPessoaFisicaMOD = PessoaFisicaRPO.Consultar(id),
                    LisDependentePessoaFisicaMOD = DependentePessoaFisicaRPO.Listar(id),
                    LisContatoPessoaFisicaMOD = ContatoPessoaFisicaRPO.Listar(id),
                    LisPlanosMOD = PlanoRPO.Listar(),
                    LisStatusMOD = StatusRPO.Listar(),
                };
                return alterarPessoaFisicaVM;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void ActionAlterarPessoaFisica(AlterarPessoaFisicaVM alterarPessoaFisicaVM)
        {
            if (DefinirPessoaFisicaId(alterarPessoaFisicaVM))
            {
                PessoaFisicaRPO.Alterar(alterarPessoaFisicaVM.ObjPessoaFisicaMOD);
                ContatoPessoaFisicaRPO.Alterar(alterarPessoaFisicaVM.LisContatoPessoaFisicaMOD);
                DependentePessoaFisicaRPO.Alterar(alterarPessoaFisicaVM.LisDependentePessoaFisicaMOD);
            }
        }

        public static bool DefinirPessoaFisicaId(AlterarPessoaFisicaVM alterarPessoaFisicaVM)
        {
            try
            {
                foreach (var item in alterarPessoaFisicaVM.LisDependentePessoaFisicaMOD)
                {
                    item.PessoaFisicaId = alterarPessoaFisicaVM.ObjPessoaFisicaMOD.Id;
                }

                foreach (var item in alterarPessoaFisicaVM.LisContatoPessoaFisicaMOD)
                {
                    item.PessoaFisicaId = alterarPessoaFisicaVM.ObjPessoaFisicaMOD.Id;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
