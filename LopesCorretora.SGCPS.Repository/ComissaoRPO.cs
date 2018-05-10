﻿using System;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;
using System.Collections.Generic;

namespace LopesCorretora.SGCPS.Repository
{
    public class ComissaoRPO
    {
        public static void Alterar(ComissaoMOD comissaoMOD)
        {
            try
            {
                using (SGCPSContext contex = new SGCPSContext())
                {
                    ComissaoMOD ObjComissaoMOD = contex.Comissoes.Where(x => x.Id == comissaoMOD.Id).First();
                    ObjComissaoMOD.NumeroDaParcela = comissaoMOD.NumeroDaParcela;
                    ObjComissaoMOD.PlanoId = comissaoMOD.PlanoId;
                    ObjComissaoMOD.Comissao = comissaoMOD.Comissao;
                    ObjComissaoMOD.Tipo = comissaoMOD.Tipo;
                    contex.Comissoes.Update(ObjComissaoMOD);
                    contex.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Cadastrar(ComissaoMOD comissaoMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.Comissoes.Add(comissaoMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Consultar(int PlanoId)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.Comissoes.ToList().Where(x => x.Id == 1);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<ComissaoMOD> Listar(int IdPlano)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    return context.Comissoes.Where(x => x.PlanoId == IdPlano).ToList();
                }
            }
            catch (Exception)
            {
                return new List<ComissaoMOD>();
            }
        }
    }
}