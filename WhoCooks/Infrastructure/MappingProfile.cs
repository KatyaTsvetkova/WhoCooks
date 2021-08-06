namespace WhoCooks.Infrastructure
{
    using AutoMapper;
    using WhoCooks.Data;
    using WhoCooks.Models.Home;
    using WhoCooks.Models.Recipes;
    using WhoCooks.Services.Recipes;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            this.CreateMap<RecipeDetailsServiceModel, RecipesFormModel>();
            this.CreateMap<Recipe, RecipeDetailsServiceModel>()
                .ForMember(c => c.UserId, cfg => cfg.MapFrom(c => c.Chef.UserId));
            this.CreateMap<Recipe, RecipeIndexViewModel>();
        }
    }
}
