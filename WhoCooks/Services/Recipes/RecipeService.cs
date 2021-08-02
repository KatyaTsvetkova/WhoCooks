namespace WhoCooks.Services.Recipes
{
    using System.Collections.Generic;
    using System.Linq;
    using WhoCooks.Data;
    using WhoCooks.Models;


    public class RecipeService : IRecipeService
    {
        private readonly WhoCooksDbContext data;

        public RecipeService(WhoCooksDbContext data) 
            => this.data = data;

        public RecipesQueryServiceModel All(
            string title,
            string searchTerm,
            RecipeSorting sorting,
            int currentPage,
            int recipePerPage)
        {
            var recipesQuery = this.data.Recipes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                recipesQuery = recipesQuery.Where(c => c.Title == title);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                recipesQuery = recipesQuery.Where(c =>
                    (c.Title).ToLower().Contains(searchTerm.ToLower()) ||
                    c.Directions.ToLower().Contains(searchTerm.ToLower()));
            }

            recipesQuery = sorting switch
            {
                RecipeSorting.Category => recipesQuery.OrderByDescending(c => c.Category),
                RecipeSorting.Difficulty => recipesQuery.OrderBy(c => c.Difficulty),
                RecipeSorting.CreatedOn or _ => recipesQuery.OrderByDescending(c => c.Id)
            };

            var totalRecipes = recipesQuery.Count();

            var recipe = recipesQuery
                .Skip((currentPage - 1) * recipePerPage)
                .Take(recipePerPage)
                .Select(r => new RecipeServiceModel
                {
                    Title = r.Title,
                    Difficulty=r.Difficulty,
                    CookTime=r.CookTime,
                    ImageUrl=r.ImageUrl,
                    Category = r.Category.Name
                })
                .ToList();

            return new RecipesQueryServiceModel
            {
                TotalRecipes = totalRecipes,
                CurrentPage = currentPage,
                RecipesPerPage = recipePerPage,
                Recipes = recipe
            };
        }

        public IEnumerable<string> AllRecipes()
            => this.data
                .Recipes
                .Select(c => c.Title)
                .Distinct()
                .OrderBy(br => br)
                .ToList();
    }
}
