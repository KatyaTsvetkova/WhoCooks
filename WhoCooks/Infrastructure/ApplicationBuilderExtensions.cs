namespace WhoCooks.Infrastructure
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using WhoCooks.Data; 
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using static WebConstants;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            SeedCategories(services);
            SeedAdministrator(services);

            return app;
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<WhoCooksDbContext>();

            data.Database.Migrate();
        }
        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<WhoCooksDbContext>();

            if (data.Categories.Any())
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
           data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole {Name = AdministratorRoleName};

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@whocooks.com";
                    const string adminPassword = "cookie";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail,
                        FullName = "Admin"
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
