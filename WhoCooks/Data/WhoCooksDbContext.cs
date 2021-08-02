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
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Recipe>()
                .HasOne(c => c.Category)
                .WithMany(c => c.RecipeCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
  
            base.OnModelCreating(builder);
        }
    }
}
