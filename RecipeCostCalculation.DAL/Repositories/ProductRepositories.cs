using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    public class ProductRepositories : IBaseRepositories<ProductEntity>
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(ProductEntity entity)
        {
            await _appDbContext.Products.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(ProductEntity entity)
        {
            _appDbContext.Products.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<ProductEntity> GetAll()
        {
            return _appDbContext.Products;
        }

        public async Task<ProductEntity> Update(ProductEntity entity)
        {
            _appDbContext.Products.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
