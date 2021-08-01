namespace WhoCooks.Services.Recipes
{
    using System.Collections.Generic;

    public class RecipesQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int RecipesPerPage { get; init; }

        public int TotalRecipes { get; init; }

        public IEnumerable<RecipeServiceModel> Recipes { get; init; }
    }
}
