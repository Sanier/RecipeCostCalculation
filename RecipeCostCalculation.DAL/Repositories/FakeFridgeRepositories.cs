using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    public class FakeFridgeRepositories : IBaseRepositories<FridgeEntity>
    {
        private List<FridgeEntity> _fridges;
        public async Task Create(FridgeEntity entity)
        {
            _fridges.Add(entity);
            await Task.CompletedTask;
        }

        public async Task Delete(FridgeEntity entity)
        {
            _fridges.Remove(entity);
            await Task.CompletedTask;
        }

        public IQueryable<FridgeEntity> GetAll()
        {
            return _fridges.AsQueryable();
        }

        public async Task<FridgeEntity> Update(FridgeEntity entity)
        {
            await Task.CompletedTask;
            return entity;
        }
    }
}
