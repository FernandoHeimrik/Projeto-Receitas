using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.DAL
{
    public class ComentarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarComentario(Comentario c)
        {
            ctx.Comentarios.Add(c);
            ctx.SaveChanges();
        }

        public static List<Comentario> BuscarComentariosPorReceita(int? idReceita)
        {
            return ctx.Comentarios.Where(x => x.Receita.ReceitaId == idReceita).ToList();
        }

    }
}