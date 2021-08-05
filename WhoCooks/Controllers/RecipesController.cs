namespace WhoCooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using WhoCooks.Data;
    using WhoCooks.Models;
    using WhoCooks.Models.Recipes;
    using WhoCooks.Services.Recipes;
    using Microsoft.AspNetCore.Authorization;
    using WhoCooks.Infrastructure;

    public class RecipesController : Controller
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
         
        [Authorize]
        public IActionResult Add()
        {
            return View(new RecipesFormModel()
            {
                Categories = this.recipe.AllCategories()

            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(RecipesFormModel recipe)
        {

            if (!this.recipe.CategoryExists(recipe.CategoryId))
            {
                this.ModelState.AddModelError(nameof(recipe.CategoryId), "Category does not exist.");
            }


            if (!ModelState.IsValid)
            {
                recipe.Categories = this.recipe.AllCategories();

                return View(recipe);
            }

            this.recipe.Create(
                recipe.Title,
                recipe.Difficulty,
                recipe.Directions,
                recipe.ImageUrl,
                recipe.Ingredients,
                recipe.Servings,
                recipe.CookTime,
                recipe.CategoryId,
                recipe.ChefId);

            return RedirectToAction(nameof(All));

        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var recipeDetails = this.recipe.Details(id);

            return View(new RecipesFormModel()
            {
                Title = recipeDetails.Title,
                Difficulty = recipeDetails.Difficulty,
                Servings = recipeDetails.Servings,
                CookTime = recipeDetails.CookTime,
                Ingredients = recipeDetails.Ingredients,
                Directions = recipeDetails.Directions,
                ImageUrl = recipeDetails.ImageUrl,
                CategoryId = recipeDetails.CategoryId,
                Categories = this.recipe.AllCategories()
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, RecipesFormModel currentRecipe)
        {
           
            if (!this.recipe.CategoryExists(currentRecipe.CategoryId))
            {
                this.ModelState.AddModelError(nameof(currentRecipe.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                currentRecipe.Categories = this.recipe.AllCategories();

                return View(currentRecipe);
            }
             
            this.recipe.Edit(
                id,
                currentRecipe.Title,
                currentRecipe.Difficulty,
                currentRecipe.Servings,
                currentRecipe.CookTime,
                currentRecipe.ImageUrl,
                currentRecipe.Ingredients,
                currentRecipe.CategoryId, 
                currentRecipe.Directions);

            return RedirectToAction(nameof(All));
        }
    }
}
