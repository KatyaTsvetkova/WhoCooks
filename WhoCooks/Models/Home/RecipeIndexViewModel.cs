namespace WhoCooks.Models.Home
{
    public class RecipeIndexViewModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public int Difficulty { get; set; }
       
        public string ImageUrl { get; init; }

        public double CookTime { get; set; }
    }
}
