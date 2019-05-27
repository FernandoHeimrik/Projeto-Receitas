namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Perfis", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Perfis", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Perfis", "Senha", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Perfis", "Senha", c => c.String());
            AlterColumn("dbo.Perfis", "Email", c => c.String());
            AlterColumn("dbo.Perfis", "Nome", c => c.String());
        }
    }
}
