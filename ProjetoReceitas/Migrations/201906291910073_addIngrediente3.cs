namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIngrediente3 : DbMigration
    {
        public override void Up()
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
            CreateIndex("dbo.ItemIngrediente", "Ingrediente_IngredienteId");
            AddForeignKey("dbo.ItemIngrediente", "Ingrediente_IngredienteId", "dbo.Ingredientes", "IngredienteId");
            DropColumn("dbo.ItemIngrediente", "Ingrediente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemIngrediente", "Ingrediente", c => c.String());
            DropForeignKey("dbo.ItemIngrediente", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropIndex("dbo.ItemIngrediente", new[] { "Ingrediente_IngredienteId" });
            DropColumn("dbo.ItemIngrediente", "Ingrediente_IngredienteId");
            DropTable("dbo.Ingredientes");
        }
    }
}
