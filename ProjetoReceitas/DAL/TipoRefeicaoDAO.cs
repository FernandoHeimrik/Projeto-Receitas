using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.DAL
{
    public class TipoRefeicaoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();


        public static bool CadastrarTipoRefeicao(TipoRefeicao tr)
        {
            if (BuscarTipoDeRefeicaoPorNome(tr) == null)
            {
                ctx.TiposRefeicoes.Add(tr);
                ctx.SaveChanges();

                return true;
            }
            return false;
        }

        public static TipoRefeicao BuscarTipoDeRefeicaoPorNome(TipoRefeicao tr)
        {
            return ctx.TiposRefeicoes.FirstOrDefault(x => x.Nome.Equals(tr.Nome));
        }

        public static List<TipoRefeicao> RetornarTiposRefeicoes()
        {
            return ctx.TiposRefeicoes.ToList();
        }

        public static void RemoverTipoRefeicao(TipoRefeicao tr)
        {
            ctx.TiposRefeicoes.Remove(tr);
            ctx.SaveChanges();
        }

        public static void AlterarTipoRefeicao(TipoRefeicao tr)
        {
            ctx.Entry(tr).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static TipoRefeicao BuscarTipoRefeicaoPorId(int? id)
        {
            return ctx.TiposRefeicoes.Find(id);
        }
    }
}