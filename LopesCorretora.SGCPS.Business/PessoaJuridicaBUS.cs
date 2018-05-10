using System;
using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;
using LopesCorretora.SGCPS.ViewsModels;

namespace LopesCorretora.SGCPS.Business
{
    public class PessoaJuridicaBUS
    {
        #region Cadastrar Pessoa Juridica
        public static CadastrarPessoaJuridicaVM CadastrarPessoaJuridicaVMGet()
        {
            try
            {
                return new CadastrarPessoaJuridicaVM()
                {
                    //ObjUsuarioMOD = new UsuarioMOD(),
                    ObjPessoaJuridicaMOD = new PessoaJuridicaMOD(),
                    LisPlanoMOD = PlanoRPO.Listar(),
                    ListStatusMOD = StatusRPO.Listar()
                };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static CadastrarPessoaJuridicaVM CadastrarPessoaJuridicaVMPost(CadastrarPessoaJuridicaVM cadastrarPessoaJuridicaVM)
        {
            try
            {
                cadastrarPessoaJuridicaVM.LisPlanoMOD = PlanoRPO.Listar();
                cadastrarPessoaJuridicaVM.ListStatusMOD = StatusRPO.Listar();
                return cadastrarPessoaJuridicaVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarPessoaJuridicaVM CadastrarPessoaJuridica(CadastrarPessoaJuridicaVM cadastrarPessoaJuridicaVM)
        {
            try
            {
                PessoaJuridicaRPO.Cadastrar(cadastrarPessoaJuridicaVM.ObjPessoaJuridicaMOD);
                BindCadastrarPjVM(cadastrarPessoaJuridicaVM);
                ContatoPessoaFisicaBUS.CadastrarContatosPessoaJuridica(cadastrarPessoaJuridicaVM.LisContatoPessoaJuridicaMOD);
                PlanoPessoaJuridicaBUS.CadastrarPlanoPessoaJuridica(cadastrarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD);
                CadastrarPessoaJuridicaVMPost(cadastrarPessoaJuridicaVM);
                return cadastrarPessoaJuridicaVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void BindCadastrarPjVM(CadastrarPessoaJuridicaVM cadastrarPessoaJuridicaVM)
        {
            foreach (var item in cadastrarPessoaJuridicaVM.LisContatoPessoaJuridicaMOD)
            {
                item.PessoaJuridicaId = cadastrarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id;
            }

            foreach (var item in cadastrarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD)
            {
                item.PessoaJuridicaId = cadastrarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id;
            }
        }
        #endregion

        #region Alterar Pessoa Juridica
        public static AlterarPessoaJuridicaVM Consultar(int id)
        {
            return new AlterarPessoaJuridicaVM
            {
                ObjPessoaJuridicaMOD = PessoaJuridicaRPO.Consultar(id),
                LisContatoPessoaJuridicaMOD = ContatoPessoaJuridicaRPO.Listar(id),
                ListPlanoPessoaJuridicaMOD = PlanoPessoaJuridicaRPO.Listar(id),
                LisPlanoMOD = PlanoRPO.Listar(),
                ListStatusMOD = StatusRPO.Listar()
            };
        }

        public static AlterarPessoaJuridicaVM AlterarPessoaJuridicaVM()
        {
            return new AlterarPessoaJuridicaVM
            {
                ListStatusMOD = StatusRPO.Listar(),
                LisPlanoMOD = PlanoRPO.Listar()
            };
        }

        public static AlterarPessoaJuridicaVM AlterarPessoaJuridicaVM(AlterarPessoaJuridicaVM alterarPessoaJuridicaVM)
        {
            alterarPessoaJuridicaVM.ListStatusMOD = StatusRPO.Listar();
            alterarPessoaJuridicaVM.LisPlanoMOD = PlanoRPO.Listar();
            return alterarPessoaJuridicaVM;
        }

        public static AlterarPessoaJuridicaVM AlterarPessoaJuridica(AlterarPessoaJuridicaVM alterarPessoaJuridicaVM)
        {
            BindAlterarPjVM(alterarPessoaJuridicaVM);
            PessoaJuridicaRPO.Alterar(alterarPessoaJuridicaVM.ObjPessoaJuridicaMOD);
            PlanoPessoaJuridicaBUS.AlterarPlanoPessoaJuridica(alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD);
            ContatoPessoaJuridicaBUS.AlterarContatosPessoasJuridicas(alterarPessoaJuridicaVM.LisContatoPessoaJuridicaMOD);

            return AlterarPessoaJuridicaVM(alterarPessoaJuridicaVM);
        }

        public static void BindAlterarPjVM(AlterarPessoaJuridicaVM alterarPessoaJuridicaVM)
        {
            foreach (var item in alterarPessoaJuridicaVM.LisContatoPessoaJuridicaMOD)
            {
                item.PessoaJuridicaId = alterarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id;
            }

            foreach (var item in alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD)
            {
                item.NumeroContrato = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].NumeroContrato;
                item.NumeroDeBeneficiarios = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].NumeroDeBeneficiarios;
                item.NumeroDeParcelas = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].NumeroDeParcelas;
                item.Observacoes = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].Observacoes;
                item.Odontologia = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].Odontologia;
                item.Participacao = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].Participacao;
                item.PessoaJuridicaId = alterarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id;
                item.PlanoId = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].PlanoId;
                item.QualOdonto = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].QualOdonto;
                item.UsuarioId = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMOD[0].UsuarioId;
            }
        }
        #endregion
    }
}
