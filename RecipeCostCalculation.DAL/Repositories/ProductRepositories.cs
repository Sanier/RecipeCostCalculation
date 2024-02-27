using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    /// <summary>
    /// The ProductRepositories class implements the IBaseRepositories interface for ProductEntity.
    /// </summary>
    public class ProductRepositories : IBaseRepositories<ProductEntity>
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Constructor for the ProductRepositories class.
        /// </summary>
        /// <param name="appDbContext">The database context.</param>
        public ProductRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Asynchronously creates a new product in the database.
        /// </summary>
        /// <param name="entity">The product to be created.</param>
        public async Task Create(ProductEntity entity)
        {
            await _appDbContext.Products.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously deletes a product from the database.
        /// </summary>
        /// <param name="entity">The product to be deleted</param>
        public async Task Delete(ProductEntity entity)
        {
            _appDbContext.Products.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        /// <returns>An IQueryable of ProductEntity.</returns>
        public IQueryable<ProductEntity> GetAll()
        {
            return _appDbContext.Products;
        }

        /// <summary>
        /// Asynchronously updates a product in the database.
        /// </summary>
        /// <param name="entity">The product to be updated.</param>
        public async Task<ProductEntity> Update(ProductEntity entity)
        {
            _appDbContext.Products.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
