using RecipeCostCalculation.Domain.Entities;
using RecipeCostCalculation.Domain.Models.RecipeModels;
using RecipeCostCalculation.Domain.Response;

namespace RecipeCostCalculation.Service.Interfaces
{
    public interface IRecipeService
    {
        Task<IBaseResponse<IEnumerable<RecipeModel>>> GetRecipes();
        Task<IBaseResponse<RecipeEntity>> Create(RecipeModel createRecipeModel);
        Task<IBaseResponse<IEnumerable<RecipeModel>>> DeleteRecipes(long id);
        Task<IBaseResponse<IEnumerable<RecipeModel>>> ChangeRecipes(RecipeModel model);
    }
}
