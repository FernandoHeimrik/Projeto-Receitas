namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPerfil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Perfis", "Tipo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Perfis", "Tipo");
        }
    }
}
