namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIngrediente2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemIngrediente", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropIndex("dbo.ItemIngrediente", new[] { "Ingrediente_IngredienteId" });
            AddColumn("dbo.ItemIngrediente", "Ingrediente", c => c.String());
            AddColumn("dbo.ItemIngrediente", "Quantidade", c => c.Int(nullable: false));
            AddColumn("dbo.ItemIngrediente", "UnidadeMedida", c => c.String(nullable: false));
            DropColumn("dbo.ItemIngrediente", "Ingrediente_IngredienteId");
            DropTable("dbo.Ingredientes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ingredientes",
                c => new
                    {
                        IngredienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        UnidadeMedida = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IngredienteId);
            
            AddColumn("dbo.ItemIngrediente", "Ingrediente_IngredienteId", c => c.Int());
            DropColumn("dbo.ItemIngrediente", "UnidadeMedida");
            DropColumn("dbo.ItemIngrediente", "Quantidade");
            DropColumn("dbo.ItemIngrediente", "Ingrediente");
            CreateIndex("dbo.ItemIngrediente", "Ingrediente_IngredienteId");
            AddForeignKey("dbo.ItemIngrediente", "Ingrediente_IngredienteId", "dbo.Ingredientes", "IngredienteId");
        }
    }
}
