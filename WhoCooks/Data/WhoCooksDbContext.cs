namespace WhoCooks.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
   


    public class WhoCooksDbContext : IdentityDbContext
    {
        public WhoCooksDbContext(DbContextOptions<WhoCooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; init; }
        public  DbSet<Category> Categories { get; init; }
        public DbSet<CookingMethod> CookingMethods { get; init; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Recipe>()
                .HasOne(c => c.Category)
                .WithMany(c => c.RecipeCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Recipe>()
                .HasOne(c => c.CookingMethod)
                .WithMany(c => c.RecipeMethods)
                .HasForeignKey(c => c.CookingMethodId)
                .OnDelete(DeleteBehavior.Restrict);
  
            base.OnModelCreating(builder);
        }
    }
}
