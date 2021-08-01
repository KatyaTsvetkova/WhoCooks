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
            var totalChefs = this.data.Users.Count();

            return new StatisticsServiceModel
            {
                TotalRecipes = totalRecipes,
                TotalChefs = totalChefs
                 
            };
        }
    }
}
