namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReceita : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receitas",
                c => new
                    {
                        ReceitaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        TempoPreparo = c.Int(nullable: false),
                        Imagem = c.String(),
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
            
            AddColumn("dbo.Comentarios", "Receitas_ReceitaId", c => c.Int());
            CreateIndex("dbo.Comentarios", "Receitas_ReceitaId");
            AddForeignKey("dbo.Comentarios", "Receitas_ReceitaId", "dbo.Receitas", "ReceitaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receitas", "Usuario_PerfilId", "dbo.Perfis");
            DropForeignKey("dbo.Receitas", "TipoRefeicao_TipoRefeicaoId", "dbo.TiposRefeicoes");
            DropForeignKey("dbo.Receitas", "NivelDificuldade_DificuldadeId", "dbo.NiveisDificuldades");
            DropForeignKey("dbo.Comentarios", "Receitas_ReceitaId", "dbo.Receitas");
            DropIndex("dbo.Receitas", new[] { "Usuario_PerfilId" });
            DropIndex("dbo.Receitas", new[] { "TipoRefeicao_TipoRefeicaoId" });
            DropIndex("dbo.Receitas", new[] { "NivelDificuldade_DificuldadeId" });
            DropIndex("dbo.Comentarios", new[] { "Receitas_ReceitaId" });
            DropColumn("dbo.Comentarios", "Receitas_ReceitaId");
            DropTable("dbo.Receitas");
        }
    }
}
