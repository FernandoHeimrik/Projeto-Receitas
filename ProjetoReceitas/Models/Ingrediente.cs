using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{
    [Table("Ingredientes")]
    public class Ingrediente
    {
        [Key]
        public int IngredienteId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Ingrediente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Unidade de Medida")]
        public string UnidadeMedida { get; set; }
    }
}