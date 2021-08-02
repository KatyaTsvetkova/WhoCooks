namespace WhoCooks.Models.Recipes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WhoCooks.Services.Recipes;

    public class AllRecipesQueryModel
    {

        public const int RecipesPerPage = 5;
        public string Title { get; init; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; }

        public RecipeSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalRecipes { get; set; }
        public IEnumerable<string> Titles { get; set; }

        public IEnumerable<RecipeServiceModel> Recipes { get; set; }

    }
}
