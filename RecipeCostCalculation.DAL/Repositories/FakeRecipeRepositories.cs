using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    public class FakeRecipeRepositories : IBaseRepositories<RecipeEntity>
    {
        private List<RecipeEntity> _recipes;
        public async Task Create(RecipeEntity entity)
        {
            _recipes.Add(entity);
            await Task.CompletedTask;
        }

        public async Task Delete(RecipeEntity entity)
        {
            _recipes.Remove(entity);
            await Task.CompletedTask;
        }

        public IQueryable<RecipeEntity> GetAll()
        {
            return _recipes.AsQueryable();
        }

        public async Task<RecipeEntity> Update(RecipeEntity entity)
        {
            await Task.CompletedTask;
            return entity;
        }
    }
}
