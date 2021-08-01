
namespace WhoCooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using WhoCooks.Data;
    using WhoCooks.Models;
    using WhoCooks.Models.Recipes;


    public class RecipesController :Controller
    {

        private readonly WhoCooksDbContext data;

        public RecipesController(WhoCooksDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add()
        {
            return View(new AddRecipeFormModel()
            {
                Categories = this.GetRecipesCategories(),
                Methods = this.GetRecipesMethods()
            });
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

        private IEnumerable<MethodsViewModel> GetRecipesMethods()
            => this.data
                .CookingMethods
                .Select(m => new MethodsViewModel
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .ToList();
    }
        
}
