namespace WhoCooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Generic; 
    using System.Linq; 
    using WhoCooks.Services.Recipes;

    public class HomeController : Controller
    {
        private readonly IRecipeService recipes;
        private readonly IMemoryCache cache;

        public HomeController(
            IRecipeService recipes,
            IMemoryCache cache)
        {
            this.recipes = recipes;
            this.cache = cache;
        }

        public IActionResult Index()
        {
            const string latestRecipesCacheKey = "LatestCarsCacheKey";

            var latestRecipe = this.cache.Get<List<LatestRecipeServiceModel>>(latestRecipesCacheKey);

            if (latestRecipe == null)
            {
                //latestRecipe = this.recipes
                   //.Latest()
                   //.ToList();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(15));

                this.cache.Set(latestRecipesCacheKey, latestRecipe, cacheOptions);
            }

            return View(latestRecipe);
        }

        public IActionResult Error() => View();
    }
}
