using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    public class FakeFridgeRepositories : IBaseRepositories<FridgeEntity>
    {
        private List<FridgeEntity> _fridges = new List<FridgeEntity>();
        public async Task Create(FridgeEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _fridges.Add(entity);
            await Task.CompletedTask;
        }

        public async Task Delete(FridgeEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _fridges.Remove(entity);
            await Task.CompletedTask;
        }

        public IQueryable<FridgeEntity> GetAll()
        {
            return _fridges.AsQueryable();
        }

        public async Task<FridgeEntity> Update(FridgeEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            var emp = _fridges.FirstOrDefault(f => f.Id == entity.Id);
            if (emp != null)
            {
                emp.Name = entity.Name;
                emp.Count = entity.Count;
                emp.Price = entity.Price;
                emp.EnergyValue = entity.EnergyValue;
                emp.DateOfManufacture = entity.DateOfManufacture;
                emp.ExpirationDate = entity.ExpirationDate;
            }

            await Task.CompletedTask;
            return entity;
        }
    }
}
