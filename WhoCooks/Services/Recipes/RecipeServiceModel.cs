namespace WhoCooks.Services.Recipes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class RecipeServiceModel
    {
        public int Id { get; init; }
        
        public string Title { get; init; }
        
        public int Difficulty { get; init; }

        public int Servings { get; init; }

        public double CookTime { get; init; }
        
        public string Ingredients { get; init; }

        public DateTime TimeStamp { get; set; } 

        public string ImageUrl { get; init; }

        public string Directions { get; init; }

        [Required]

        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public string Category { get; init; }

        public  int ChefId { get; init; }
    }
}
