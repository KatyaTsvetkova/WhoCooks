namespace WhoCooks.Services.Recipes
{
    using System.Collections.Generic;
    using WhoCooks.Services.Recipes;
    using WhoCooks.Models;
    
    public interface IRecipeService
    {
        RecipesQueryServiceModel All(
            string brand,
            string searchTerm,
            RecipeSorting sorting,
            int currentPage,
            int carsPerPage);

        IEnumerable<string> AllRecipes();
    }
}
