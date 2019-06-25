namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIngredienteAndEtapaAndModoDePreparo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModosDePreparo",
                c => new
                    {
                        ModoId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        UnidadeMedida = c.String(nullable: false),
                        Etapa_EtapaId = c.Int(nullable: false),
                        Ingrediente_IngredienteId = c.Int(nullable: false),
                        Receita_ReceitaId = c.Int(),
                    })
                .PrimaryKey(t => t.ModoId)
                .ForeignKey("dbo.Etapas", t => t.Etapa_EtapaId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredientes", t => t.Ingrediente_IngredienteId, cascadeDelete: true)
                .ForeignKey("dbo.Receitas", t => t.Receita_ReceitaId)
                .Index(t => t.Etapa_EtapaId)
                .Index(t => t.Ingrediente_IngredienteId)
                .Index(t => t.Receita_ReceitaId);
            
            CreateTable(
                "dbo.Etapas",
                c => new
                    {
                        EtapaId = c.Int(nullable: false, identity: true),
                        Posicao = c.Int(nullable: false),
                        Descricao = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EtapaId);
            
            CreateTable(
                "dbo.Ingredientes",
                c => new
                    {
                        IngredienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IngredienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModosDePreparo", "Receita_ReceitaId", "dbo.Receitas");
            DropForeignKey("dbo.ModosDePreparo", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropForeignKey("dbo.ModosDePreparo", "Etapa_EtapaId", "dbo.Etapas");
            DropIndex("dbo.ModosDePreparo", new[] { "Receita_ReceitaId" });
            DropIndex("dbo.ModosDePreparo", new[] { "Ingrediente_IngredienteId" });
            DropIndex("dbo.ModosDePreparo", new[] { "Etapa_EtapaId" });
            DropTable("dbo.Ingredientes");
            DropTable("dbo.Etapas");
            DropTable("dbo.ModosDePreparo");
        }
    }
}
