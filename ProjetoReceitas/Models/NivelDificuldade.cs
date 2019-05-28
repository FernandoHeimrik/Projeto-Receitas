using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{
    [Table("NiveisDificuldades")]
    public class NivelDificuldade
    {
        [Key]
        public int DificuldadeId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nivel de Dificuldade")]
        public string Nome { get; set; }

        public List<Receita> Receitas { get; set; }
    }
}