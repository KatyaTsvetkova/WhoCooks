namespace WhoCooks.Services.Recipes
{
    using System.Collections.Generic;
    using System.Linq;
    using WhoCooks.Data;
    using WhoCooks.Models;
    using System;
    using AutoMapper;
    using AutoMapper.QueryableExtensions; 
 


    public class RecipeService : IRecipeService
    {
        private readonly WhoCooksDbContext data;
        private readonly IConfigurationProvider mapper;
        public RecipeService(WhoCooksDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }

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
        public int Create(string title, 
            int difficulty, 
            string directions, 
            string imageUrl, 
            string ingredients,
            int servings, 
            double cookTime,
            int categoryId, 
            int chefId)
        {
            var recipeData = new Recipe
            {
                Title = title,
                Difficulty = difficulty,
                Ingredients= ingredients,
                Directions = directions,
                ImageUrl = imageUrl,
                CookTime = cookTime,
                Servings = servings,
                TimeStamp = DateTime.UtcNow,
                CategoryId = categoryId,
                ChefId = chefId
            };

            this.data.Recipes.Add(recipeData);
            this.data.SaveChanges();

            return recipeData.Id;
        }
        public bool Edit(
            int recipeId,
            string title,
            int difficulty,
            int servings,
            double cookTime,
            string imageUrl,
            string ingredients,
            int categoryId,
            string directions)
        {
            var recipeData = this.data.Recipes.Find(recipeId);

            if (recipeData == null)
            {
                return false;
            }

            recipeData.Title = title;
            recipeData.Difficulty = difficulty;
            recipeData.Servings = servings;
            recipeData.CookTime = cookTime;
            recipeData.Ingredients = ingredients;
            recipeData.TimeStamp = DateTime.UtcNow;
            recipeData.ImageUrl = imageUrl;
            recipeData.Directions = directions;
            recipeData.CategoryId = categoryId;

            this.data.SaveChanges();

            return true;
        }
        public RecipeServiceModel Details(int id)
            => this.data
                .Recipes
                .Where(r => r.Id == id)
                .ProjectTo<RecipeDetailsServiceModel>(this.mapper)
                .FirstOrDefault();
        public IEnumerable<RecipeServiceModel> ByUser(string userId)
            => GetRecipe(this.data
                .Recipes
                .Where(c => c.Chef.UserId == userId));

        public IEnumerable<RecipeCategoryServiceModel> AllCategories()
            => this.data
                .Categories
                .Select(c => new RecipeCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

        public bool CategoryExists(int categoryId)
            => this.data
                .Categories
                .Any(c => c.Id == categoryId);

        public IEnumerable<string> AllRecipes()
            => this.data
                .Recipes
                .Select(c => c.Title)
                .Distinct()
                .OrderBy(br => br)
                .ToList();

        private static IEnumerable<RecipeServiceModel> GetRecipe(IQueryable<Recipe> recipeQuery)
            => recipeQuery
                .Select(r => new RecipeServiceModel
                {
                   Id=r.Id,
                   Title = r.Title,
                   Difficulty = r.Difficulty,
                   Directions = r.Directions,
                   ImageUrl = r.ImageUrl,
                   Ingredients = r.Ingredients,
                   Servings = r.Servings,
                   CookTime = r.CookTime,
                   CategoryId = r.CategoryId,
                   ChefId = r.ChefId,
                   TimeStamp = DateTime.UtcNow

                })
                .ToList();
    }
}
