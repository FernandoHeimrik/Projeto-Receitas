using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{
    [Table("TiposRefeicoes")]
    public class TipoRefeicao
    {
        [Key]
        public int TipoRefeicaoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Tipo da Refeição")]
        public string Nome { get; set; }

        public List<Receita> Receitas { get; set; }

    }
}