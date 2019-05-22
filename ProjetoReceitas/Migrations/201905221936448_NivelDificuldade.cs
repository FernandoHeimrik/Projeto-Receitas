namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NivelDificuldade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NiveisDificuldades",
                c => new
                    {
                        DificuldadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DificuldadeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NiveisDificuldades");
        }
    }
}
