namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTipoRefeicao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TiposRefeicoes",
                c => new
                    {
                        TipoRefeicaoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TipoRefeicaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TiposRefeicoes");
        }
    }
}
