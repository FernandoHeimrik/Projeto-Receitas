namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPerfilAndComentario : DbMigration
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
                        Usuario_PerfilId = c.Int(),
                    })
                .PrimaryKey(t => t.ComentarioId)
                .ForeignKey("dbo.Perfis", t => t.Usuario_PerfilId)
                .Index(t => t.Usuario_PerfilId);
            
            CreateTable(
                "dbo.Perfis",
                c => new
                    {
                        PerfilId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PerfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "Usuario_PerfilId", "dbo.Perfis");
            DropIndex("dbo.Comentarios", new[] { "Usuario_PerfilId" });
            DropTable("dbo.Perfis");
            DropTable("dbo.Comentarios");
        }
    }
}
