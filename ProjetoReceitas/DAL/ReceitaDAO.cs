using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.DAL
{
    public class ReceitaDAO
    {
        public static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarReceita(Receita r)
        {
            if(BuscarReceitaPorTitulo(r) == null)
            {
                ctx.Receitas.Add(r);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Receita BuscarReceitaPorTitulo(Receita r)
        {
            return ctx.Receitas.FirstOrDefault(x => x.Titulo.Equals(r.Titulo));
        }

        public static List<Receita> RetornarReceitas()
        {
            return ctx.Receitas.Include("TipoRefeicao").Include("NivelDificuldade").Include("Ingredientes").ToList();
        }

        public static void AlterarReceita(Receita r)
        {
            
            ctx.Entry(r).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static Receita BuscarReceitaPorTipo(Receita r)
        {
            return ctx.Receitas.Include("TipoRefeicao").FirstOrDefault(x => x.TipoRefeicao.Equals(r.TipoRefeicao));
        }

        public static Receita BuscarReceitaPorNivelDificuldade(Receita r)
        {
            return ctx.Receitas.Include("NivelDificuldade").FirstOrDefault(x => x.NivelDificuldade.Equals(r.NivelDificuldade));
        }

        public static Receita BuscarReceitaPorId(int? id)
        {
            return ctx.Receitas.Find(id);
        }

        public static void RemoverReceita(Receita r)
        {
            ctx.Receitas.Remove(r);
            ctx.SaveChanges();
        }
    }
}