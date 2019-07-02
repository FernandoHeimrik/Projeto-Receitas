namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class api : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meals", "strInstructions");
            DropColumn("dbo.Meals", "strTags");
            DropColumn("dbo.Meals", "strYoutube");
            DropColumn("dbo.Meals", "strIngredient1");
            DropColumn("dbo.Meals", "strIngredient2");
            DropColumn("dbo.Meals", "strIngredient3");
            DropColumn("dbo.Meals", "strIngredient4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "strIngredient4", c => c.String());
            AddColumn("dbo.Meals", "strIngredient3", c => c.String());
            AddColumn("dbo.Meals", "strIngredient2", c => c.String());
            AddColumn("dbo.Meals", "strIngredient1", c => c.String());
            AddColumn("dbo.Meals", "strYoutube", c => c.String());
            AddColumn("dbo.Meals", "strTags", c => c.String());
            AddColumn("dbo.Meals", "strInstructions", c => c.String());
        }
    }
}
