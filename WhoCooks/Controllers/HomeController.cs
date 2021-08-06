namespace WhoCooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using System;
    using System.Collections.Generic; 
    using System.Linq; 
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using WhoCooks.Data;
    using WhoCooks.Models.Home;
    using WhoCooks.Services.Statistics;
    using WhoCooks.Services.Recipes;

    public class HomeController : Controller
    {
        private readonly IRecipeService recipes;
        private readonly IMemoryCache cache;
        private readonly IConfigurationProvider mapper;
        private readonly WhoCooksDbContext data;
        private readonly IStatisticsService statistics;
        public HomeController(
            IRecipeService recipes,
            IMemoryCache cache,
            WhoCooksDbContext data, 
            IStatisticsService statistics,
            IMapper mapper)
        {
            this.recipes = recipes;
            this.cache = cache;
            this.mapper = mapper.ConfigurationProvider;
            this.data = data;
            this.statistics = statistics;
        }

        public IActionResult Index()
        {
            var recipe = this.data
                .Recipes
                .OrderByDescending(c => c.Id)
                .ProjectTo<RecipeIndexViewModel>(this.mapper)
                .Take(3)
                .ToList();

            var totalStatistics = this.statistics.Total();

            return View(new IndexViewModel
            {
                TotalRecipes = totalStatistics.TotalRecipes,
                TotalUsers = totalStatistics.TotalUsers,
                Recipes = recipe
            });
        }

        public IActionResult Error() => View();
    }
}
