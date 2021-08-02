namespace WhoCooks.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using WhoCooks.Models.Recipes;

    using static Data.DataConstants;
    public class RecipesFormModel
    {


        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; init; }

        [Required]
        [MinLength(AuthorMinLength)]
        public string Author { get; init; }

        [Required] 
        public int Difficulty { get; init; }

        [Required]
        public int Servings { get; init; }

        [Required] 
        public double CookTime { get; init; }

        [Required] 
        public string Ingredients { get; init; }
        
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow.ToLocalTime();

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        [StringLength(
            int.MaxValue,
            MinimumLength = DirectionsMinLength,
            ErrorMessage = "The field Description must be a string with a minimum length of {2}.")]
        public string Directions { get; init; }
        
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
