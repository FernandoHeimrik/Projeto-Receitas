using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{
    [Table("Meals")]
    public class Meal
    {
        [Key]
        public string idMeal { get; set; }
        public string strMeal { get; set; }
        public string strCategory { get; set; }
        public string strArea { get; set; }
    
        
    }
}