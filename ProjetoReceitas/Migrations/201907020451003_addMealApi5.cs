namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMealApi5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "strDrinkAlternate", c => c.String());
            AddColumn("dbo.Meals", "strIngredient16", c => c.String());
            AddColumn("dbo.Meals", "strIngredient17", c => c.String());
            AddColumn("dbo.Meals", "strIngredient18", c => c.String());
            AddColumn("dbo.Meals", "strIngredient19", c => c.String());
            AddColumn("dbo.Meals", "strIngredient20", c => c.String());
            AddColumn("dbo.Meals", "strMeasure16", c => c.String());
            AddColumn("dbo.Meals", "strMeasure17", c => c.String());
            AddColumn("dbo.Meals", "strMeasure18", c => c.String());
            AddColumn("dbo.Meals", "strMeasure19", c => c.String());
            AddColumn("dbo.Meals", "strMeasure20", c => c.String());
            AddColumn("dbo.Meals", "strSource", c => c.String());
            AddColumn("dbo.Meals", "dateModified", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "dateModified");
            DropColumn("dbo.Meals", "strSource");
            DropColumn("dbo.Meals", "strMeasure20");
            DropColumn("dbo.Meals", "strMeasure19");
            DropColumn("dbo.Meals", "strMeasure18");
            DropColumn("dbo.Meals", "strMeasure17");
            DropColumn("dbo.Meals", "strMeasure16");
            DropColumn("dbo.Meals", "strIngredient20");
            DropColumn("dbo.Meals", "strIngredient19");
            DropColumn("dbo.Meals", "strIngredient18");
            DropColumn("dbo.Meals", "strIngredient17");
            DropColumn("dbo.Meals", "strIngredient16");
            DropColumn("dbo.Meals", "strDrinkAlternate");
        }
    }
}
