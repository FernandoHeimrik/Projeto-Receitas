using ProjetoReceitas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.DAL
{
    public class MealDAO
    {
        public static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarMealApi(Meal meal)
        {
            try
            {
                if (BuscarMealPorTitulo(meal) == null)
                {
                    ctx.Meals.Add(meal);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public static Meal BuscarMealPorTitulo(Meal meal)
        {
            return ctx.Meals.FirstOrDefault(x => x.strMeal.Equals(meal.strMeal));
        }

        public static List<Meal> RetornarMeals()
        {
            return ctx.Meals.ToList();
        }

        public static void AlterarMeal(Meal meal)
        {
            ctx.Entry(meal).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public static Meal BuscarMealPorId(string id)
        {
            return ctx.Meals.Find(id);
        }

        public static void RemoverMeal(Meal meal)
        {
            ctx.Meals.Remove(meal);
            ctx.SaveChanges();
        }
    }
}