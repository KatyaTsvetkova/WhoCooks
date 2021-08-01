namespace WhoCooks.Data
{
    using System.Collections.Generic;
    public class CookingMethod
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public IEnumerable<Recipe> RecipeMethods { get; init; } = new List<Recipe>();
    }
}
