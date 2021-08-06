namespace WhoCooks.Services.Statistics
{
    using System.Linq;
    using WhoCooks.Data;

    public class StatisticsService : IStatisticsService
    {
        private readonly WhoCooksDbContext data;

        public StatisticsService(WhoCooksDbContext data)
            => this.data = data;

        public StatisticsServiceModel Total()
        {
            var totalRecipes = this.data.Recipes.Count();
            var totalUsers = this.data.Users.Count();
            var totalArticles = this.data.Articles.Count();

            return new StatisticsServiceModel
            {
                TotalRecipes = totalRecipes,
                TotalUsers = totalUsers,
                TotalArticles= totalArticles

            };
        }
    }
}
