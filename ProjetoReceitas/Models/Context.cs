using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoReceitas.Models
{
    public class Context : DbContext
    {
        public Context() : base("DbReceitas") { }

        public DbSet<NivelDificuldade> NiveisDificuldades { get; set; }
        public DbSet<TipoRefeicao> TiposRefeicoes { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Receita> Receitas { get; set; }

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<ItemIngredienteReceita> ItensIngrediente { get; set; }


    }
}