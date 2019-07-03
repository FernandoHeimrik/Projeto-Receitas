namespace ProjetoReceitas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mealApi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receitas", "Usuario_PerfilId", "dbo.Perfis");
            DropIndex("dbo.Receitas", new[] { "Usuario_PerfilId" });
            AddColumn("dbo.Receitas", "Usuario", c => c.String());
            AddColumn("dbo.Meals", "strInstructions", c => c.String());
            AddColumn("dbo.Meals", "strMealThumb", c => c.String());
            AddColumn("dbo.Meals", "strTags", c => c.String());
            AddColumn("dbo.Meals", "strYoutube", c => c.String());
            AddColumn("dbo.Meals", "strIngredient1", c => c.String());
            AddColumn("dbo.Meals", "strIngredient2", c => c.String());
            AddColumn("dbo.Meals", "strIngredient3", c => c.String());
            AddColumn("dbo.Meals", "strIngredient4", c => c.String());
            AddColumn("dbo.Meals", "strIngredient5", c => c.String());
            AddColumn("dbo.Meals", "strIngredient6", c => c.String());
            AddColumn("dbo.Meals", "strIngredient7", c => c.String());
            AddColumn("dbo.Meals", "strIngredient8", c => c.String());
            AddColumn("dbo.Meals", "strIngredient9", c => c.String());
            AddColumn("dbo.Meals", "strIngredient10", c => c.String());
            AddColumn("dbo.Meals", "strIngredient11", c => c.String());
            AddColumn("dbo.Meals", "strIngredient12", c => c.String());
            AddColumn("dbo.Meals", "strIngredient13", c => c.String());
            AddColumn("dbo.Meals", "strIngredient14", c => c.String());
            AddColumn("dbo.Meals", "strIngredient15", c => c.String());
            AddColumn("dbo.Meals", "strMeasure1", c => c.String());
            AddColumn("dbo.Meals", "strMeasure2", c => c.String());
            AddColumn("dbo.Meals", "strMeasure3", c => c.String());
            AddColumn("dbo.Meals", "strMeasure4", c => c.String());
            AddColumn("dbo.Meals", "strMeasure5", c => c.String());
            AddColumn("dbo.Meals", "strMeasure6", c => c.String());
            AddColumn("dbo.Meals", "strMeasure7", c => c.String());
            AddColumn("dbo.Meals", "strMeasure8", c => c.String());
            AddColumn("dbo.Meals", "strMeasure9", c => c.String());
            AddColumn("dbo.Meals", "strMeasure10", c => c.String());
            AddColumn("dbo.Meals", "strMeasure11", c => c.String());
            AddColumn("dbo.Meals", "strMeasure12", c => c.String());
            AddColumn("dbo.Meals", "strMeasure13", c => c.String());
            AddColumn("dbo.Meals", "strMeasure14", c => c.String());
            AddColumn("dbo.Meals", "strMeasure15", c => c.String());
            AddColumn("dbo.Meals", "Usuario", c => c.String());
            DropColumn("dbo.Receitas", "Usuario_PerfilId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Receitas", "Usuario_PerfilId", c => c.Int());
            DropColumn("dbo.Meals", "Usuario");
            DropColumn("dbo.Meals", "strMeasure15");
            DropColumn("dbo.Meals", "strMeasure14");
            DropColumn("dbo.Meals", "strMeasure13");
            DropColumn("dbo.Meals", "strMeasure12");
            DropColumn("dbo.Meals", "strMeasure11");
            DropColumn("dbo.Meals", "strMeasure10");
            DropColumn("dbo.Meals", "strMeasure9");
            DropColumn("dbo.Meals", "strMeasure8");
            DropColumn("dbo.Meals", "strMeasure7");
            DropColumn("dbo.Meals", "strMeasure6");
            DropColumn("dbo.Meals", "strMeasure5");
            DropColumn("dbo.Meals", "strMeasure4");
            DropColumn("dbo.Meals", "strMeasure3");
            DropColumn("dbo.Meals", "strMeasure2");
            DropColumn("dbo.Meals", "strMeasure1");
            DropColumn("dbo.Meals", "strIngredient15");
            DropColumn("dbo.Meals", "strIngredient14");
            DropColumn("dbo.Meals", "strIngredient13");
            DropColumn("dbo.Meals", "strIngredient12");
            DropColumn("dbo.Meals", "strIngredient11");
            DropColumn("dbo.Meals", "strIngredient10");
            DropColumn("dbo.Meals", "strIngredient9");
            DropColumn("dbo.Meals", "strIngredient8");
            DropColumn("dbo.Meals", "strIngredient7");
            DropColumn("dbo.Meals", "strIngredient6");
            DropColumn("dbo.Meals", "strIngredient5");
            DropColumn("dbo.Meals", "strIngredient4");
            DropColumn("dbo.Meals", "strIngredient3");
            DropColumn("dbo.Meals", "strIngredient2");
            DropColumn("dbo.Meals", "strIngredient1");
            DropColumn("dbo.Meals", "strYoutube");
            DropColumn("dbo.Meals", "strTags");
            DropColumn("dbo.Meals", "strMealThumb");
            DropColumn("dbo.Meals", "strInstructions");
            DropColumn("dbo.Receitas", "Usuario");
            CreateIndex("dbo.Receitas", "Usuario_PerfilId");
            AddForeignKey("dbo.Receitas", "Usuario_PerfilId", "dbo.Perfis", "PerfilId");
        }
    }
}
