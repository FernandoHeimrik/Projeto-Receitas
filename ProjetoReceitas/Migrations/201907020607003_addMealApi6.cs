namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMealApi6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meals", "strDrinkAlternate");
            DropColumn("dbo.Meals", "strMealThumb");
            DropColumn("dbo.Meals", "strIngredient5");
            DropColumn("dbo.Meals", "strIngredient6");
            DropColumn("dbo.Meals", "strIngredient7");
            DropColumn("dbo.Meals", "strIngredient8");
            DropColumn("dbo.Meals", "strIngredient9");
            DropColumn("dbo.Meals", "strIngredient10");
            DropColumn("dbo.Meals", "strIngredient11");
            DropColumn("dbo.Meals", "strIngredient12");
            DropColumn("dbo.Meals", "strIngredient13");
            DropColumn("dbo.Meals", "strIngredient14");
            DropColumn("dbo.Meals", "strIngredient15");
            DropColumn("dbo.Meals", "strIngredient16");
            DropColumn("dbo.Meals", "strIngredient17");
            DropColumn("dbo.Meals", "strIngredient18");
            DropColumn("dbo.Meals", "strIngredient19");
            DropColumn("dbo.Meals", "strIngredient20");
            DropColumn("dbo.Meals", "strMeasure1");
            DropColumn("dbo.Meals", "strMeasure2");
            DropColumn("dbo.Meals", "strMeasure3");
            DropColumn("dbo.Meals", "strMeasure4");
            DropColumn("dbo.Meals", "strMeasure5");
            DropColumn("dbo.Meals", "strMeasure6");
            DropColumn("dbo.Meals", "strMeasure7");
            DropColumn("dbo.Meals", "strMeasure8");
            DropColumn("dbo.Meals", "strMeasure9");
            DropColumn("dbo.Meals", "strMeasure10");
            DropColumn("dbo.Meals", "strMeasure11");
            DropColumn("dbo.Meals", "strMeasure12");
            DropColumn("dbo.Meals", "strMeasure13");
            DropColumn("dbo.Meals", "strMeasure14");
            DropColumn("dbo.Meals", "strMeasure15");
            DropColumn("dbo.Meals", "strMeasure16");
            DropColumn("dbo.Meals", "strMeasure17");
            DropColumn("dbo.Meals", "strMeasure18");
            DropColumn("dbo.Meals", "strMeasure19");
            DropColumn("dbo.Meals", "strMeasure20");
            DropColumn("dbo.Meals", "strSource");
            DropColumn("dbo.Meals", "dateModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "dateModified", c => c.String());
            AddColumn("dbo.Meals", "strSource", c => c.String());
            AddColumn("dbo.Meals", "strMeasure20", c => c.String());
            AddColumn("dbo.Meals", "strMeasure19", c => c.String());
            AddColumn("dbo.Meals", "strMeasure18", c => c.String());
            AddColumn("dbo.Meals", "strMeasure17", c => c.String());
            AddColumn("dbo.Meals", "strMeasure16", c => c.String());
            AddColumn("dbo.Meals", "strMeasure15", c => c.String());
            AddColumn("dbo.Meals", "strMeasure14", c => c.String());
            AddColumn("dbo.Meals", "strMeasure13", c => c.String());
            AddColumn("dbo.Meals", "strMeasure12", c => c.String());
            AddColumn("dbo.Meals", "strMeasure11", c => c.String());
            AddColumn("dbo.Meals", "strMeasure10", c => c.String());
            AddColumn("dbo.Meals", "strMeasure9", c => c.String());
            AddColumn("dbo.Meals", "strMeasure8", c => c.String());
            AddColumn("dbo.Meals", "strMeasure7", c => c.String());
            AddColumn("dbo.Meals", "strMeasure6", c => c.String());
            AddColumn("dbo.Meals", "strMeasure5", c => c.String());
            AddColumn("dbo.Meals", "strMeasure4", c => c.String());
            AddColumn("dbo.Meals", "strMeasure3", c => c.String());
            AddColumn("dbo.Meals", "strMeasure2", c => c.String());
            AddColumn("dbo.Meals", "strMeasure1", c => c.String());
            AddColumn("dbo.Meals", "strIngredient20", c => c.String());
            AddColumn("dbo.Meals", "strIngredient19", c => c.String());
            AddColumn("dbo.Meals", "strIngredient18", c => c.String());
            AddColumn("dbo.Meals", "strIngredient17", c => c.String());
            AddColumn("dbo.Meals", "strIngredient16", c => c.String());
            AddColumn("dbo.Meals", "strIngredient15", c => c.String());
            AddColumn("dbo.Meals", "strIngredient14", c => c.String());
            AddColumn("dbo.Meals", "strIngredient13", c => c.String());
            AddColumn("dbo.Meals", "strIngredient12", c => c.String());
            AddColumn("dbo.Meals", "strIngredient11", c => c.String());
            AddColumn("dbo.Meals", "strIngredient10", c => c.String());
            AddColumn("dbo.Meals", "strIngredient9", c => c.String());
            AddColumn("dbo.Meals", "strIngredient8", c => c.String());
            AddColumn("dbo.Meals", "strIngredient7", c => c.String());
            AddColumn("dbo.Meals", "strIngredient6", c => c.String());
            AddColumn("dbo.Meals", "strIngredient5", c => c.String());
            AddColumn("dbo.Meals", "strMealThumb", c => c.String());
            AddColumn("dbo.Meals", "strDrinkAlternate", c => c.String());
        }
    }
}
