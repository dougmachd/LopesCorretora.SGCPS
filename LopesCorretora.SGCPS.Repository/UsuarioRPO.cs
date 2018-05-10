using System;
using LopesCorretora.SGCPS.Repository.DataAccess;
using LopesCorretora.SGCPS.Models;
using System.Linq;

namespace LopesCorretora.SGCPS.Repository
{
    public class UsuarioRPO
    {
        public static void Alterar(UsuarioMOD usuarioMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    UsuarioMOD ObjUsuarioMOD = context.Usuarios.Where(x => x.Id == usuarioMOD.Id).First();
                    ObjUsuarioMOD.Nome = usuarioMOD.Nome;
                    ObjUsuarioMOD.CPF = usuarioMOD.CPF;
                    ObjUsuarioMOD.Email = usuarioMOD.Email;
                    ObjUsuarioMOD.Celular = usuarioMOD.Celular;
                    ObjUsuarioMOD.Concessionario = usuarioMOD.Concessionario;
                    context.Usuarios.Update(ObjUsuarioMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static void Cadastrar(UsuarioMOD usuarioMOD)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    context.Usuarios.Add(usuarioMOD);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static UsuarioMOD Consultar(int Id)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    return context.Usuarios.Where(x => x.Id == Id).First();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static UsuarioMOD Consultar(string email)
        {
            try
            {
                using (SGCPSContext context = new SGCPSContext())
                {
                    return context.Usuarios.Where(x => x.Email.Equals(email)).First();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
