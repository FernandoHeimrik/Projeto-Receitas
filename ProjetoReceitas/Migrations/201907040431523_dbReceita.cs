namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbReceita : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ComentarioId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        DataCriacao = c.DateTime(nullable: false),
                        Usuario = c.String(),
                        Receita_ReceitaId = c.Int(),
                    })
                .PrimaryKey(t => t.ComentarioId)
                .ForeignKey("dbo.Receitas", t => t.Receita_ReceitaId)
                .Index(t => t.Receita_ReceitaId);
            
            CreateTable(
                "dbo.Receitas",
                c => new
                    {
                        ReceitaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        TempoPreparo = c.Int(nullable: false),
                        Imagem = c.String(),
                        Usuario = c.String(),
                        ModoDePreparo = c.String(),
                        SessaoReceitaId = c.String(),
                        Ingrediente_IngredienteId = c.Int(),
                        NivelDificuldade_DificuldadeId = c.Int(),
                        TipoRefeicao_TipoRefeicaoId = c.Int(),
                    })
                .PrimaryKey(t => t.ReceitaId)
                .ForeignKey("dbo.Ingredientes", t => t.Ingrediente_IngredienteId)
                .ForeignKey("dbo.NiveisDificuldades", t => t.NivelDificuldade_DificuldadeId)
                .ForeignKey("dbo.TiposRefeicoes", t => t.TipoRefeicao_TipoRefeicaoId)
                .Index(t => t.Ingrediente_IngredienteId)
                .Index(t => t.NivelDificuldade_DificuldadeId)
                .Index(t => t.TipoRefeicao_TipoRefeicaoId);
            
            CreateTable(
                "dbo.ItemIngrediente",
                c => new
                    {
                        ItemIngredienteReceitaId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        UnidadeMedida = c.String(),
                        SessaoReceitaId = c.String(),
                        Ingrediente_IngredienteId = c.Int(),
                        Receita_ReceitaId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemIngredienteReceitaId)
                .ForeignKey("dbo.Ingredientes", t => t.Ingrediente_IngredienteId)
                .ForeignKey("dbo.Receitas", t => t.Receita_ReceitaId)
                .Index(t => t.Ingrediente_IngredienteId)
                .Index(t => t.Receita_ReceitaId);
            
            CreateTable(
                "dbo.Ingredientes",
                c => new
                    {
                        IngredienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IngredienteId);
            
            CreateTable(
                "dbo.NiveisDificuldades",
                c => new
                    {
                        DificuldadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DificuldadeId);
            
            CreateTable(
                "dbo.TiposRefeicoes",
                c => new
                    {
                        TipoRefeicaoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoRefeicaoId);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        idMeal = c.String(nullable: false, maxLength: 128),
                        strMeal = c.String(),
                        strCategory = c.String(),
                        strArea = c.String(),
                        strInstructions = c.String(),
                        strMealThumb = c.String(),
                        strTags = c.String(),
                        strYoutube = c.String(),
                        strIngredient1 = c.String(),
                        strIngredient2 = c.String(),
                        strIngredient3 = c.String(),
                        strIngredient4 = c.String(),
                        strIngredient5 = c.String(),
                        strIngredient6 = c.String(),
                        strIngredient7 = c.String(),
                        strIngredient8 = c.String(),
                        strIngredient9 = c.String(),
                        strIngredient10 = c.String(),
                        strIngredient11 = c.String(),
                        strIngredient12 = c.String(),
                        strIngredient13 = c.String(),
                        strIngredient14 = c.String(),
                        strIngredient15 = c.String(),
                        strMeasure1 = c.String(),
                        strMeasure2 = c.String(),
                        strMeasure3 = c.String(),
                        strMeasure4 = c.String(),
                        strMeasure5 = c.String(),
                        strMeasure6 = c.String(),
                        strMeasure7 = c.String(),
                        strMeasure8 = c.String(),
                        strMeasure9 = c.String(),
                        strMeasure10 = c.String(),
                        strMeasure11 = c.String(),
                        strMeasure12 = c.String(),
                        strMeasure13 = c.String(),
                        strMeasure14 = c.String(),
                        strMeasure15 = c.String(),
                        Usuario = c.String(),
                    })
                .PrimaryKey(t => t.idMeal);
            
            CreateTable(
                "dbo.Perfis",
                c => new
                    {
                        PerfilId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false, maxLength: 100),
                        DataCriacao = c.DateTime(nullable: false),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PerfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receitas", "TipoRefeicao_TipoRefeicaoId", "dbo.TiposRefeicoes");
            DropForeignKey("dbo.Receitas", "NivelDificuldade_DificuldadeId", "dbo.NiveisDificuldades");
            DropForeignKey("dbo.ItemIngrediente", "Receita_ReceitaId", "dbo.Receitas");
            DropForeignKey("dbo.Receitas", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropForeignKey("dbo.ItemIngrediente", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropForeignKey("dbo.Comentarios", "Receita_ReceitaId", "dbo.Receitas");
            DropIndex("dbo.ItemIngrediente", new[] { "Receita_ReceitaId" });
            DropIndex("dbo.ItemIngrediente", new[] { "Ingrediente_IngredienteId" });
            DropIndex("dbo.Receitas", new[] { "TipoRefeicao_TipoRefeicaoId" });
            DropIndex("dbo.Receitas", new[] { "NivelDificuldade_DificuldadeId" });
            DropIndex("dbo.Receitas", new[] { "Ingrediente_IngredienteId" });
            DropIndex("dbo.Comentarios", new[] { "Receita_ReceitaId" });
            DropTable("dbo.Perfis");
            DropTable("dbo.Meals");
            DropTable("dbo.TiposRefeicoes");
            DropTable("dbo.NiveisDificuldades");
            DropTable("dbo.Ingredientes");
            DropTable("dbo.ItemIngrediente");
            DropTable("dbo.Receitas");
            DropTable("dbo.Comentarios");
        }
    }
}
