using Microsoft.Extensions.Logging;
using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Models.RecipeModels;
using RecipeCostCalculation.Domain.Response;
using RecipeCostCalculation.Service.Interfaces;

namespace RecipeCostCalculation.Service.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IBaseRepositories<RecipeEntity> _recipeRepository;
        private ILogger<RecipeService> _logger;

        public RecipeService(IBaseRepositories<RecipeEntity> recipeRepository, ILogger<RecipeService> logger)
        {
            _recipeRepository = recipeRepository;
            _logger = logger;
        }

        public async Task<IBaseResponse<IEnumerable<RecipeModel>>> ChangeRecipes(RecipeModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<RecipeEntity>> Create(RecipeModel createRecipeModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<IEnumerable<RecipeModel>>> DeleteRecipes(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<IEnumerable<RecipeModel>>> GetRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
