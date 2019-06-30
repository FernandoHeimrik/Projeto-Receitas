using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{
    [Table("Receitas")]
    public class Receita
    {
        [Key]
        public int ReceitaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }

        [Display(Name = "Tipo da Refeição")]
        public TipoRefeicao TipoRefeicao { get; set; }

        [Display(Name = "Nivel de Dificuldade")]
        public NivelDificuldade NivelDificuldade { get; set; }

        [Display(Name = "Tempo de Preparo")]
        public int TempoPreparo { get; set; }

        [Display(Name = "Comentarios")]
        public List<Comentario> Comentarios { get; set; }

        [Display(Name = "Imagem")]
        public string Imagem { get; set; }

        [Display(Name = "Usuario")]
        public Perfil Usuario { get; set; }

        [Display(Name = "Modo de Preparo")]
        public string ModoDePreparo { get; set; }

        [Display(Name = "Ingredientes")]
        public List<ItemIngredienteReceita> Ingredientes { get; set; }

        public string SessaoReceitaId { get; set; }

    }
}