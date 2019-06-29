namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIngrediente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredientes", "Quantidade", c => c.Int(nullable: false));
            AddColumn("dbo.Ingredientes", "UnidadeMedida", c => c.String(nullable: false));
            DropColumn("dbo.ItemIngrediente", "Quantidade");
            DropColumn("dbo.ItemIngrediente", "UnidadeMedida");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemIngrediente", "UnidadeMedida", c => c.String(nullable: false));
            AddColumn("dbo.ItemIngrediente", "Quantidade", c => c.Int(nullable: false));
            DropColumn("dbo.Ingredientes", "UnidadeMedida");
            DropColumn("dbo.Ingredientes", "Quantidade");
        }
    }
}
