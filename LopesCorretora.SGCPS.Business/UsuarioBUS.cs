using LopesCorretora.SGCPS.Models;
using LopesCorretora.SGCPS.Repository;

namespace LopesCorretora.SGCPS.Business
{
    public class UsuarioBUS
    {
        public static UsuarioMOD IsValid(UsuarioMOD usuarioMOD)
        {
            return UsuarioRPO.Consultar(usuarioMOD.Email);
        }

        public static UsuarioMOD Consultar(int id)
        {
            return UsuarioRPO.Consultar(id);
        }

        public static void Alterar(UsuarioMOD usuarioMOD)
        {
            UsuarioRPO.Alterar(usuarioMOD);
        }

        public static void Cadastrar(UsuarioMOD usuarioMOD)
        {
            UsuarioRPO.Cadastrar(usuarioMOD);
        }

        public static void RetornarEmail(UsuarioMOD usuarioMOD)
        {
            foreach (var item in usuarioMOD.principal.Claims)
            {
                usuarioMOD.Email = item.Value;
            }
        }
    }
}
