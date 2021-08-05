using System.Collections.Specialized;
using Microsoft.VisualBasic;

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

        int Create(string title,
            int difficulty,
            string directions,
            string imageUrl,
            string ingredients,
            int servings,
            double cookTime,
            int categoryId,
            int chefId);
        RecipeServiceModel Details(int recipeId);
        bool Edit(
            int recipeId,
            string title,
            int difficulty,
            int servings,
            double cookTime,
            string imageUrl,
            string ingredients,
            int categoryId,
            string directions
            );
        IEnumerable<RecipeServiceModel> ByUser(string userId);
          
        IEnumerable<RecipeCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);
    }
}

