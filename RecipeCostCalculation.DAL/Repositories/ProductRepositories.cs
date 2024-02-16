using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    public class ProductRepositories : IBaseRepositories<ProductEntity>
    {
        public Task Create(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> Update(ProductEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
