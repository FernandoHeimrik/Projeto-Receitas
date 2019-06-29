using ProjetoReceitas.Models;
using ProjetoReceitas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.DAL
{
    public class ItemIngredienteReceitaDAO
    {
        public static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarItemIngrediente(ItemIngredienteReceita itemIngrediente)
        {
            string itemReceitaId = Sessao.RetornarItemReceitaId();
            ctx.ItensIngrediente.Add(itemIngrediente);
            ctx.SaveChanges();
        }

        public static void RemoverItemIngrediente(ItemIngredienteReceita itemIngrediente)
        {
            ctx.ItensIngrediente.Remove(itemIngrediente);
            ctx.SaveChanges();
        }

        public static List<ItemIngredienteReceita> RetornarItemIngrediente()
        {
            string itemReceitaId = Sessao.RetornarItemReceitaId();
            return ctx.ItensIngrediente.Include("Ingrediente").Where(x => x.SessaoReceitaId.Equals(itemReceitaId)).ToList();
        }

        public static ItemIngredienteReceita BuscarItemIngredientePorId(int? id)
        {
            return ctx.ItensIngrediente.Find(id);
        }
    }
}