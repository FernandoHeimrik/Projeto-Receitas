using ProjetoReceitas.Models;
using ProjetoReceitas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.DAL
{
    public class IngredienteDAO
    {
        public static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarIngrediente(Ingrediente i)
        {
            if(BuscarIngredientePorNome(i) != null)
            {
                ctx.Ingredientes.Add(i);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        private static Ingrediente BuscarIngredientePorNome(Ingrediente i)
        {
            return ctx.Ingredientes.FirstOrDefault(x => x.Nome.Equals(i.Nome));
        }

        public static void RemoverIngrediente(Ingrediente i)
        {
            ctx.Ingredientes.Remove(i);
            ctx.SaveChanges();
        }

        public static void AlterarIngrediente(Ingrediente i)
        {
            ctx.Entry(i).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static List<Ingrediente> RetornarIngredientes()
        {
            return ctx.Ingredientes.ToList();
        }

        public static Ingrediente BuscarIngredientePorId(int? id)
        {
            return ctx.Ingredientes.Find(id);
        }
    }
}