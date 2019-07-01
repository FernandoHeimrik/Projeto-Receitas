namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        ModoDePreparo = c.String(),
                        SessaoReceitaId = c.String(),
                        NivelDificuldade_DificuldadeId = c.Int(),
                        TipoRefeicao_TipoRefeicaoId = c.Int(),
                        Usuario_PerfilId = c.Int(),
                    })
                .PrimaryKey(t => t.ReceitaId)
                .ForeignKey("dbo.NiveisDificuldades", t => t.NivelDificuldade_DificuldadeId)
                .ForeignKey("dbo.TiposRefeicoes", t => t.TipoRefeicao_TipoRefeicaoId)
                .ForeignKey("dbo.Perfis", t => t.Usuario_PerfilId)
                .Index(t => t.NivelDificuldade_DificuldadeId)
                .Index(t => t.TipoRefeicao_TipoRefeicaoId)
                .Index(t => t.Usuario_PerfilId);
            
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
            DropForeignKey("dbo.Receitas", "Usuario_PerfilId", "dbo.Perfis");
            DropForeignKey("dbo.Receitas", "TipoRefeicao_TipoRefeicaoId", "dbo.TiposRefeicoes");
            DropForeignKey("dbo.Receitas", "NivelDificuldade_DificuldadeId", "dbo.NiveisDificuldades");
            DropForeignKey("dbo.ItemIngrediente", "Receita_ReceitaId", "dbo.Receitas");
            DropForeignKey("dbo.ItemIngrediente", "Ingrediente_IngredienteId", "dbo.Ingredientes");
            DropForeignKey("dbo.Comentarios", "Receita_ReceitaId", "dbo.Receitas");
            DropIndex("dbo.ItemIngrediente", new[] { "Receita_ReceitaId" });
            DropIndex("dbo.ItemIngrediente", new[] { "Ingrediente_IngredienteId" });
            DropIndex("dbo.Receitas", new[] { "Usuario_PerfilId" });
            DropIndex("dbo.Receitas", new[] { "TipoRefeicao_TipoRefeicaoId" });
            DropIndex("dbo.Receitas", new[] { "NivelDificuldade_DificuldadeId" });
            DropIndex("dbo.Comentarios", new[] { "Receita_ReceitaId" });
            DropTable("dbo.Perfis");
            DropTable("dbo.TiposRefeicoes");
            DropTable("dbo.NiveisDificuldades");
            DropTable("dbo.Ingredientes");
            DropTable("dbo.ItemIngrediente");
            DropTable("dbo.Receitas");
            DropTable("dbo.Comentarios");
        }
    }
}
