using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhoCooks.Services.Recipes
{
    public class RecipeDetailsServiceModel:RecipeServiceModel
    {
        public string Directions { get; init; }

        public int CategoryId { get; init; }

        public int ChefId { get; init; }

        public string ChefName { get; init; }

        public string UserId { get; init; }
    }
}
