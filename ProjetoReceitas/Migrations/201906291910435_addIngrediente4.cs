namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIngrediente4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemIngrediente", "UnidadeMedida", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemIngrediente", "UnidadeMedida", c => c.String(nullable: false));
        }
    }
}
