namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Perfis", "Tipo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Perfis", "Tipo", c => c.Int(nullable: false));
        }
    }
}
