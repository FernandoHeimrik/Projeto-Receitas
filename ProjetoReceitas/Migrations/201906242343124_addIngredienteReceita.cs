namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIngredienteReceita : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ModosDePreparo", "Etapa_EtapaId", "dbo.Etapas");
            DropForeignKey("dbo.ModosDePreparo", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropForeignKey("dbo.ModosDePreparo", "Receita_ReceitaId", "dbo.Receitas");
            DropIndex("dbo.ModosDePreparo", new[] { "Etapa_EtapaId" });
            DropIndex("dbo.ModosDePreparo", new[] { "Ingrediente_IngredienteId" });
            DropIndex("dbo.ModosDePreparo", new[] { "Receita_ReceitaId" });
            AddColumn("dbo.Receitas", "ModoDePreparo", c => c.String());
            AddColumn("dbo.Ingredientes", "Quantidade", c => c.Int(nullable: false));
            AddColumn("dbo.Ingredientes", "UnidadeMedida", c => c.String(nullable: false));
            AddColumn("dbo.Ingredientes", "Receita_ReceitaId", c => c.Int());
            CreateIndex("dbo.Ingredientes", "Receita_ReceitaId");
            AddForeignKey("dbo.Ingredientes", "Receita_ReceitaId", "dbo.Receitas", "ReceitaId");
            DropTable("dbo.ModosDePreparo");
            DropTable("dbo.Etapas");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ModoId);
            
            DropForeignKey("dbo.Ingredientes", "Receita_ReceitaId", "dbo.Receitas");
            DropIndex("dbo.Ingredientes", new[] { "Receita_ReceitaId" });
            DropColumn("dbo.Ingredientes", "Receita_ReceitaId");
            DropColumn("dbo.Ingredientes", "UnidadeMedida");
            DropColumn("dbo.Ingredientes", "Quantidade");
            DropColumn("dbo.Receitas", "ModoDePreparo");
            CreateIndex("dbo.ModosDePreparo", "Receita_ReceitaId");
            CreateIndex("dbo.ModosDePreparo", "Ingrediente_IngredienteId");
            CreateIndex("dbo.ModosDePreparo", "Etapa_EtapaId");
            AddForeignKey("dbo.ModosDePreparo", "Receita_ReceitaId", "dbo.Receitas", "ReceitaId");
            AddForeignKey("dbo.ModosDePreparo", "Ingrediente_IngredienteId", "dbo.Ingredientes", "IngredienteId", cascadeDelete: true);
            AddForeignKey("dbo.ModosDePreparo", "Etapa_EtapaId", "dbo.Etapas", "EtapaId", cascadeDelete: true);
        }
    }
}
