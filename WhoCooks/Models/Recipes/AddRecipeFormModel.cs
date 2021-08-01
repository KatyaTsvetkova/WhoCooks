namespace WhoCooks.Models.Recipes
{
    using System;
    using WhoCooks.Data;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddRecipeFormModel
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

        [Required]
        public DateTime TimeStamp { get; set; }= DateTime.UtcNow.ToLocalTime();

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; init; }

        [Required]
        public string Directions { get; init; }

        [Required]
        [Display(Name = "Cooking Method")]
        public int CookingMethodId { get; init; }
        public IEnumerable<MethodsViewModel> Methods { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; init; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
