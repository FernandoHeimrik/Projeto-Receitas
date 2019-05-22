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


    }
}