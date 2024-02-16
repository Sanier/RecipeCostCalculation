using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    public class FakeProductRepositories : IBaseRepositories<ProductEntity>
    {
        private List<ProductEntity> _fridges = new List<ProductEntity>();

        public async Task Create(ProductEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _fridges.Add(entity);
            await Task.CompletedTask;
        }

        public async Task Delete(ProductEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            _fridges.Remove(entity);
            await Task.CompletedTask;
        }

        public IQueryable<ProductEntity> GetAll()
        {
            return _fridges.AsQueryable();
        }

        public async Task<ProductEntity> Update(ProductEntity entity)
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
