using System;
using System.Collections.Generic;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;

namespace LopesCorretora.SGCPS.Repository
{
    public class StatusRPO
    {
        public static void Alterar(StatusMOD statusMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.Status.Update(statusMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Cadastrar(StatusMOD statusMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.Status.Add(statusMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<StatusMOD> Listar()
        {
            try
            {
                List<StatusMOD> Status;
                using (SGCPSContext context = new SGCPSContext())
                {
                    Status = context.Status.ToList();
                }
                return Status.Count > 0 ? Status : null;
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
