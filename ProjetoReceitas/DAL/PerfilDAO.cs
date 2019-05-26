using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.DAL
{
    public class PerfilDAO
    {
        private static Context ctx = SingletonContext.GetInstance();


        public static bool CadastrarPerfilUsuario(Perfil p)
        {
            if (BuscarPerfilUsuarioPorEmail(p) == null)
            {
                ctx.Perfis.Add(p);
                ctx.SaveChanges();

                return true;
            }
            return false;
        }

        public static Perfil BuscarPerfilUsuarioPorEmail(Perfil p)
        {
            return ctx.Perfis.FirstOrDefault(x => x.Email.Equals(p.Email));
        }

        public static List<Perfil> RetornarPerfis()
        {
            return ctx.Perfis.ToList();
        }

        public static void RemoverPerfilUsuario(Perfil p)
        {
            ctx.Perfis.Remove(p);
            ctx.SaveChanges();
        }

        public static void AlterarPerfilUsuario(Perfil p)
        {
            ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static Perfil BuscarPerfilUsuarioPorEmailSenha(Perfil p)
        {
            return ctx.Perfis.FirstOrDefault(x => x.Email.Equals(p.Email) && x.Senha.Equals(p.Senha));
        }

    }
}