using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{
    [Table("ItemIngrediente")]
    public class ItemIngredienteReceita
    {
        [Key]
        public int ItemIngredienteReceitaId { get; set; }

        [Display(Name = "Ingrediente")]
        public Ingrediente Ingrediente { get; set; }

        
        public int Quantidade { get; set; }

       
        public string UnidadeMedida { get; set; }

        public string SessaoReceitaId { get; set; }
    }
}