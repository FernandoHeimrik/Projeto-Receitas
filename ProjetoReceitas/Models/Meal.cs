using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{


    public partial class Response
    {
        [JsonProperty("meals")]
        public List<Meal> Meals { get; set; }
    }


    [Table("Meals")]
    public class Meal
    {
        [Key]
        public string idMeal { get; set; }

        [Display(Name = "Meal")]
        public string strMeal { get; set; }
        [Display(Name = "Categoria")]
        public string strCategory { get; set; }
        [Display(Name = "Area")]
        public string strArea { get; set; }
        [Display(Name = "Bebida Alternativa")]
        public object strDrinkAlternate { get; set; }
        [Display(Name = "Instruções")]
        public string strInstructions { get; set; }
        [Display(Name = "MealThumb")]
        public string strMealThumb { get; set; }
        [Display(Name = "Tags")]
        public string strTags { get; set; }
        [Display(Name = "Youtube")]
        public string strYoutube { get; set; }
        [Display(Name = "Ingrediente 1")]
        public string strIngredient1 { get; set; }
        [Display(Name = "Ingrediente 2")]
        public string strIngredient2 { get; set; }
        [Display(Name = "Ingrediente 3")]
        public string strIngredient3 { get; set; }
        [Display(Name = "Ingrediente 4")]
        public string strIngredient4 { get; set; }
        [Display(Name = "Ingrediente 5")]
        public string strIngredient5 { get; set; }
        [Display(Name = "Ingrediente 6")]
        public string strIngredient6 { get; set; }
        [Display(Name = "Ingrediente7")]
        public string strIngredient7 { get; set; }
        [Display(Name = "Ingrediente8")]
        public string strIngredient8 { get; set; }
        [Display(Name = "Ingrediente 9")]
        public string strIngredient9 { get; set; }
        [Display(Name = "Ingrediente 10")]
        public string strIngredient10 { get; set; }
        [Display(Name = "Ingrediente 11")]
        public string strIngredient11 { get; set; }
        [Display(Name = "Ingrediente 12")]
        public string strIngredient12 { get; set; }
        [Display(Name = "Ingrediente 13")]
        public string strIngredient13 { get; set; }
        [Display(Name = "Ingrediente 14")]
        public string strIngredient14 { get; set; }
        [Display(Name = "Ingrediente 15")]
        public string strIngredient15 { get; set; }
        [Display(Name = "Ingrediente 16")]
        public object strIngredient16 { get; set; }
        [Display(Name = "Ingrediente 17")]
        public object strIngredient17 { get; set; }
        [Display(Name = "Ingrediente 18")]
        public object strIngredient18 { get; set; }
        [Display(Name = "Ingrediente 19")]
        public object strIngredient19 { get; set; }
        [Display(Name = "Ingrediente 20")]
        public object strIngredient20 { get; set; }
        [Display(Name = "Medida 1")]
        public string strMeasure1 { get; set; }
        [Display(Name = "Medida 2")]
        public string strMeasure2 { get; set; }
        [Display(Name = "Medida 3")]
        public string strMeasure3 { get; set; }
        [Display(Name = "Medida 4")]
        public string strMeasure4 { get; set; }
        [Display(Name = "Medida 5")]
        public string strMeasure5 { get; set; }
        [Display(Name = "Medida 6")]
        public string strMeasure6 { get; set; }
        [Display(Name = "Medida 7")]
        public string strMeasure7 { get; set; }
        [Display(Name = "Medida 8")]
        public string strMeasure8 { get; set; }
        [Display(Name = "Medida 9")]
        public string strMeasure9 { get; set; }
        [Display(Name = "Medida 10")]
        public string strMeasure10 { get; set; }
        [Display(Name = "Medida 11")]
        public string strMeasure11 { get; set; }
        [Display(Name = "Medida 12")]
        public string strMeasure12 { get; set; }
        [Display(Name = "Medida 13")]
        public string strMeasure13 { get; set; }
        [Display(Name = "Medida 14")]
        public string strMeasure14 { get; set; }
        [Display(Name = "Medida 15")]
        public string strMeasure15 { get; set; }
        [Display(Name = "Medida 16")]
        public object strMeasure16 { get; set; }
        [Display(Name = "Medida 17")]
        public object strMeasure17 { get; set; }
        [Display(Name = "Medida 18")]
        public object strMeasure18 { get; set; }
        [Display(Name = "Medida 19")]
        public object strMeasure19 { get; set; }
        [Display(Name = "Medida 20")]
        public object strMeasure20 { get; set; }
        [Display(Name = "Source")]
        public object strSource { get; set; }
        [Display(Name = "Data Modificação")]
        public object dateModified { get; set; }
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
    }
}