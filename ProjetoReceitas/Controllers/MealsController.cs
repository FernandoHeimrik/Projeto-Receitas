using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoReceitas.Models;
using RestSharp;
using Newtonsoft.Json;
using ProjetoReceitas.DAL;

namespace ProjetoReceitas.Controllers
{
    public class MealsController : Controller
    {
        public static string URL_API = "https://www.themealdb.com/api/json/v1/1/";

        public ActionResult Index()
        {
            return View(MealDAO.RetornarMeals());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = MealDAO.BuscarMealPorId(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        public ActionResult Cadastrar()
        {
            Meal meal = (Meal) TempData["Meal"];
            return View(meal);
        }

        [HttpPost]
        public ActionResult Cadastrar([Bind(Include = "idMeal,strMeal,strCategory,strArea,strInstructions,strMealThumb,strTags,strYoutube,strIngredient1,strIngredient2,strIngredient3,strIngredient4,strIngredient5,strIngredient6,strIngredient7,strIngredient8,strIngredient9,strIngredient10,strIngredient11,strIngredient12,strIngredient13,strIngredient14,strIngredient15,strMeasure1,strMeasure2,strMeasure3,strMeasure4,strMeasure5,strMeasure6,strMeasure7,strMeasure8,strMeasure9,strMeasure10,strMeasure11,strMeasure12,strMeasure13,strMeasure14,strMeasure15")] Meal meal)
        {
            ViewBag.Usuario = User.Identity.Name;
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    meal.Usuario = ViewBag.Usuario;
                }
                else
                {
                    meal.Usuario = "Desconhecido";
                }
                MealDAO.CadastrarMealApi(meal);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Já existe uma Meal com esse nome");
            return View(meal);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = MealDAO.BuscarMealPorId(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "idMeal,strMeal,strCategory,strArea,strInstructions,strMealThumb,strTags,strYoutube,strIngredient1,strIngredient2,strIngredient3,strIngredient4,strIngredient5,strIngredient6,strIngredient7,strIngredient8,strIngredient9,strIngredient10,strIngredient11,strIngredient12,strIngredient13,strIngredient14,strIngredient15,strMeasure1,strMeasure2,strMeasure3,strMeasure4,strMeasure5,strMeasure6,strMeasure7,strMeasure8,strMeasure9,strMeasure10,strMeasure11,strMeasure12,strMeasure13,strMeasure14,strMeasure15")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                MealDAO.AlterarMeal(meal);
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = MealDAO.BuscarMealPorId(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        [HttpPost]
        public ActionResult BuscarReceitaPorNome(Meal meal)
        {
            try
            {
                var cliente = new RestClient(URL_API + "search.php?s=" + meal.strMeal);
                var request = new RestRequest(Method.GET);
                IRestResponse response = cliente.Execute(request);

                var info = JsonConvert.DeserializeObject<Response>(response.Content);

                info.Meals.ForEach(x =>
                {
                    meal.strMeal = x.strMeal;
                    meal.idMeal = x.idMeal;
                    meal.strArea = x.strArea;
                    meal.strCategory = x.strCategory;
                    meal.strDrinkAlternate = x.strDrinkAlternate;
                    meal.strIngredient1 = x.strIngredient1;
                    meal.strIngredient2 = x.strIngredient2;
                    meal.strIngredient3 = x.strIngredient3;
                    meal.strIngredient4 = x.strIngredient4;
                    meal.strIngredient5 = x.strIngredient5;
                    meal.strIngredient6 = x.strIngredient6;
                    meal.strIngredient7 = x.strIngredient7;
                    meal.strIngredient8 = x.strIngredient8;
                    meal.strIngredient9 = x.strIngredient9;
                    meal.strIngredient10 = x.strIngredient10;
                    meal.strIngredient11 = x.strIngredient11;
                    meal.strIngredient12 = x.strIngredient12;
                    meal.strIngredient13 = x.strIngredient13;
                    meal.strIngredient14 = x.strIngredient14;
                    meal.strIngredient15 = x.strIngredient15;
                    meal.strIngredient16 = x.strIngredient16;
                    meal.strIngredient17 = x.strIngredient17;
                    meal.strIngredient18 = x.strIngredient18;
                    meal.strIngredient19 = x.strIngredient19;
                    meal.strIngredient20 = x.strIngredient20;
                    meal.strInstructions = x.strInstructions;
                    meal.strMealThumb = x.strMealThumb;
                    meal.strMeasure1 = x.strMeasure1;
                    meal.strMeasure2 = x.strMeasure2;
                    meal.strMeasure3 = x.strMeasure3;
                    meal.strMeasure4 = x.strMeasure4;
                    meal.strMeasure5 = x.strMeasure5;
                    meal.strMeasure6 = x.strMeasure6;
                    meal.strMeasure7 = x.strMeasure7;
                    meal.strMeasure8 = x.strMeasure8;
                    meal.strMeasure9 = x.strMeasure9;
                    meal.strMeasure10 = x.strMeasure10;
                    meal.strMeasure11 = x.strMeasure11;
                    meal.strMeasure12 = x.strMeasure12;
                    meal.strMeasure13 = x.strMeasure13;
                    meal.strMeasure14 = x.strMeasure14;
                    meal.strMeasure15 = x.strMeasure15;
                    meal.strMeasure16 = x.strMeasure16;
                    meal.strMeasure17 = x.strMeasure17;
                    meal.strMeasure18 = x.strMeasure18;
                    meal.strMeasure19 = x.strMeasure19;
                    meal.strMeasure20 = x.strMeasure20;
                    meal.strSource = x.strSource;
                    meal.strTags = x.strTags;
                    meal.strYoutube = x.strYoutube;

                });
                TempData["Meal"] = meal;
                return RedirectToAction("Cadastrar", "Meals");

            }
            catch (Exception)
            {
                string message = "Nenhuma Receita Encontrada, tente novamente";
                meal.idMeal = message;
                TempData["Meal"] = meal;
                return RedirectToAction("Cadastrar", "Meals");
            }
        }
    }
}
