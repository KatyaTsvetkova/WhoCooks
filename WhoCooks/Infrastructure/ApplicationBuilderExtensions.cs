namespace WhoCooks.Infrastructure
{
    using System.Linq;
    using WhoCooks.Data; 
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<WhoCooksDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(WhoCooksDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            if (data.CookingMethods.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Breakfast" },
                new Category { Name = "Brunch" },
                new Category { Name = "Lunch" },
                new Category { Name = "Dinner" },
                new Category { Name = "Snacks" },
                new Category { Name = "Appetisers" },
                new Category { Name = "Soups" },
                new Category { Name = "Salads" },
                new Category { Name = "Sides" },
                new Category { Name = "Pizza" },
                new Category { Name = "Rice" },
                new Category { Name = "Noodles" },
                new Category { Name = "Pasta" },
                new Category { Name = "Pies" },
                new Category { Name = "Burgers" },
                new Category { Name = "Meat" }, 
                new Category { Name = "Seafood" },
                new Category { Name = "Vegetarian" },
                new Category { Name = "Desserts" },
                new Category { Name = "Drinks" },
            });
            data.AddRange(new[]
            {
                new CookingMethod{Name = "Sauté"},
                new CookingMethod{Name = "Baking"},
                new CookingMethod{Name = "Frying"},
                new CookingMethod{Name = "Roasting"},
                new CookingMethod{Name = "Grilling"},
                new CookingMethod{Name = "Steaming"},
                new CookingMethod{Name = "Poaching"},
                new CookingMethod{Name = "Simmering"},
                new CookingMethod{Name = "Broiling"},
                new CookingMethod{Name = "Blanching"},
                new CookingMethod{Name = "Braising"},
                new CookingMethod{Name = "Stewing"},
            });

            data.SaveChanges();
        }
    }
}
