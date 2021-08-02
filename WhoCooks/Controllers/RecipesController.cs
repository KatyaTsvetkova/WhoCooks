
namespace WhoCooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using WhoCooks.Data;
    using WhoCooks.Models;
    using WhoCooks.Models.Recipes;
    using WhoCooks.Services.Recipes;

    public class RecipesController :Controller
    {

        private readonly WhoCooksDbContext data;
        private readonly IRecipeService recipe; 

        public RecipesController(WhoCooksDbContext data, IRecipeService recipe)
        {
            this.recipe = recipe;    
            this.data = data;
        }
        public IActionResult All([FromQuery] AllRecipesQueryModel query)
        {
            var queryResult = this.recipe.All(
                query.Title,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllRecipesQueryModel.RecipesPerPage);

            var recipesTitles = this.recipe.AllRecipes();

            query.Titles = recipesTitles;
            query.TotalRecipes = queryResult.TotalRecipes;
            query.Recipes = queryResult.Recipes;

            return View(query);
        }

    
        public IActionResult Add()
        {
            return View(new AddRecipeFormModel()
            {
                Categories = this.GetRecipesCategories(),
                
            });
        }
        [HttpPost]
        public IActionResult Add(AddRecipeFormModel recipe)
        {
            

            if (!this.data.Categories.Any(c => c.Id == recipe.CategoryId))
            {
                this.ModelState.AddModelError(nameof(recipe.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                recipe.Categories = this.GetRecipesCategories();

                return View(recipe);
            }

            var recipeData = new Recipe
            {
                Title= recipe.Title,
                Author= recipe.Author,
                Difficulty=recipe.Difficulty,
                Servings=recipe.Servings,
                CookTime=recipe.CookTime,
                Ingredients=recipe.Ingredients,
                TimeStamp= recipe.TimeStamp,
                ImageUrl=recipe.ImageUrl,
                Directions=recipe.Directions,
                CategoryId=recipe.CategoryId


            };

            this.data.Recipes.Add(recipeData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }
        private IEnumerable<CategoryViewModel> GetRecipesCategories()
            => this.data
                .Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToList();

       
    }
        
}
