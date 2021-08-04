namespace WhoCooks.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
   
    public class WhoCooksDbContext : IdentityDbContext<User>
    {
        public WhoCooksDbContext(DbContextOptions<WhoCooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; init; }
        public  DbSet<Category> Categories { get; init; }
        public DbSet<HowToArticle> Articles { get; init; }
        public  DbSet<Chef> Chefs { get; init; }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Recipe>()
                .HasOne(c => c.Category)
                .WithMany(c => c.RecipeCategories)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Chef>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Chef>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
