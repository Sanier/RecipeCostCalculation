using RecipeCostCalculation.DAL.Interfaces;
using RecipeCostCalculation.Domain.Entities;

namespace RecipeCostCalculation.DAL.Repositories
{
    /// <summary>
    /// The RecipeRepositories class implements the IBaseRepositories interface for RecipeEntity.
    /// </summary>
    public class RecipeRepositories : IBaseRepositories<RecipeEntity>
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Constructor for the RecipeRepositories class.
        /// </summary>
        /// <param name="appDbContext">The database context.</param>
        public RecipeRepositories(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Asynchronously creates a new recipe in the database.
        /// </summary>
        /// <param name="entity">The recipe to be created.</param>
        public async Task Create(RecipeEntity entity)
        {
            await _appDbContext.Recipe.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously deletes a recipe from the database.
        /// </summary>
        /// <param name="entity">The recipe to be deleted.</param>
        public async Task Delete(RecipeEntity entity)
        {
            _appDbContext.Recipe.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all recipes from the database.
        /// </summary>
        /// <returns>An IQueryable of RecipeEntity.</returns>
        public IQueryable<RecipeEntity> GetAll()
        {
            return _appDbContext.Recipe;
        }

        /// <summary>
        /// Asynchronously updates a recipe in the database.
        /// </summary>
        /// <param name="entity">The recipe to be updated.</param>
        public async Task<RecipeEntity> Update(RecipeEntity entity)
        {
            _appDbContext.Recipe.Update(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }
    }
}
