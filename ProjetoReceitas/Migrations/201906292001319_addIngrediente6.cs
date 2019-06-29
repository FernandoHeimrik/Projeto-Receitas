namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIngrediente6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ingredientes", "Quantidade");
            DropColumn("dbo.Ingredientes", "UnidadeMedida");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredientes", "UnidadeMedida", c => c.String(nullable: false));
            AddColumn("dbo.Ingredientes", "Quantidade", c => c.Int(nullable: false));
        }
    }
}
