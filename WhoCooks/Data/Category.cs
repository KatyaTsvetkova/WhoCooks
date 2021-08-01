namespace WhoCooks.Data
{
    using System.Collections.Generic;
    public class Category
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public IEnumerable<Recipe> RecipeCategories { get; init; } = new List<Recipe>();
    }
}
