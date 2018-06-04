using System;
using System.Collections.Generic;
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
                    LisPlanoMODs = PlanoRPO.Listar(),
                    ListStatusMODs = StatusRPO.Listar(),
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
                cadastrarPessoaJuridicaVM.LisPlanoMODs = PlanoRPO.Listar();
                cadastrarPessoaJuridicaVM.ListStatusMODs = StatusRPO.Listar();
                return cadastrarPessoaJuridicaVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static CadastrarPessoaJuridicaVM CadastrarPessoaJuridica(CadastrarPessoaJuridicaVM cadastrarPessoaJuridicaVM,
            List<int> NumeroDeBeneficiarios, List<string> Categoria, List<string> Tipos)
        {
            try
            {
                PessoaJuridicaRPO.Cadastrar(cadastrarPessoaJuridicaVM.ObjPessoaJuridicaMOD);
                BindCadastrarPjVM(cadastrarPessoaJuridicaVM, NumeroDeBeneficiarios, Categoria);
                ContatoPessoaFisicaBUS.CadastrarContatosPessoaJuridica(cadastrarPessoaJuridicaVM.LisContatoPessoaJuridicaMODs);
                PlanoPessoaJuridicaBUS.CadastrarPlanoPessoaJuridica(cadastrarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs, NumeroDeBeneficiarios, Categoria, Tipos);
                CadastrarPessoaJuridicaVMPost(cadastrarPessoaJuridicaVM);
                return cadastrarPessoaJuridicaVM;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void BindCadastrarPjVM(CadastrarPessoaJuridicaVM cadastrarPessoaJuridicaVM, List<int> NumeroDeBeneficiarios = null, List<string> Categoria = null)
        {
            foreach (var item in cadastrarPessoaJuridicaVM.LisContatoPessoaJuridicaMODs)
            {
                item.PessoaJuridicaId = cadastrarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id;
            }

            foreach (var item in cadastrarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs)
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
                LisContatoPessoaJuridicaMODs = ContatoPessoaJuridicaRPO.Listar(id),
                ListPlanoPessoaJuridicaMODs = PlanoPessoaJuridicaRPO.Listar(id),
                LisPlanoMODs = PlanoRPO.Listar(),
                ListStatusMODs = StatusRPO.Listar()
            };
        }

        public static AlterarPessoaJuridicaVM AlterarPessoaJuridicaVM()
        {
            return new AlterarPessoaJuridicaVM
            {
                ListStatusMODs = StatusRPO.Listar(),
                LisPlanoMODs = PlanoRPO.Listar()
            };
        }

        public static AlterarPessoaJuridicaVM AlterarPessoaJuridicaVM(AlterarPessoaJuridicaVM alterarPessoaJuridicaVM)
        {
            alterarPessoaJuridicaVM.ListStatusMODs = StatusRPO.Listar();
            alterarPessoaJuridicaVM.LisPlanoMODs = PlanoRPO.Listar();
            return alterarPessoaJuridicaVM;
        }

        public static AlterarPessoaJuridicaVM AlterarPessoaJuridica(AlterarPessoaJuridicaVM alterarPessoaJuridicaVM)
        {
            BindAlterarPjVM(alterarPessoaJuridicaVM);
            PessoaJuridicaRPO.Alterar(alterarPessoaJuridicaVM.ObjPessoaJuridicaMOD);
            PlanoPessoaJuridicaBUS.AlterarPlanoPessoaJuridica(alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs);
            ContatoPessoaJuridicaBUS.AlterarContatosPessoasJuridicas(alterarPessoaJuridicaVM.LisContatoPessoaJuridicaMODs);

            return AlterarPessoaJuridicaVM(alterarPessoaJuridicaVM);
        }

        public static void BindAlterarPjVM(AlterarPessoaJuridicaVM alterarPessoaJuridicaVM)
        {
            foreach (var item in alterarPessoaJuridicaVM.LisContatoPessoaJuridicaMODs)
            {
                item.PessoaJuridicaId = alterarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id;
            }

            foreach (var item in alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs)
            {
                item.NumeroContrato = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].NumeroContrato;
                item.NumeroDeBeneficiarios = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].NumeroDeBeneficiarios;
                item.NumeroDeParcelas = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].NumeroDeParcelas;
                item.Observacoes = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].Observacoes;
                item.Odontologia = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].Odontologia;
                item.Participacao = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].Participacao;
                item.PessoaJuridicaId = alterarPessoaJuridicaVM.ObjPessoaJuridicaMOD.Id;
                item.PlanoId = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].PlanoId;
                item.QualOdonto = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].QualOdonto;
                item.UsuarioId = alterarPessoaJuridicaVM.ListPlanoPessoaJuridicaMODs[0].UsuarioId;
            }
        }
        #endregion
    }
}
