namespace WhoCooks.Services.Recipes
{
    using System;
    using WhoCooks.Data;
    public class LastestRecipeServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }
        public DateTime TimeStamp { get; set; }
        public string ImageUrl { get; init; }
        public int CategoryId { get; init; }
        public Category Category { get; init; }

    }
}
