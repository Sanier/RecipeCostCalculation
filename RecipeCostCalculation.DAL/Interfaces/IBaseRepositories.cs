namespace RecipeCostCalculation.DAL.Interfaces
{
    /// <summary>
    /// The IBaseRepositories interface defines the basic operations for managing entities in the database.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IBaseRepositories<T>
    {
        /// <summary>
        /// Asynchronously creates a new entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be created.</param>
        Task Create(T entity);

        /// <summary>
        /// Gets all entities of type T from the database.
        /// </summary>
        /// <returns>An IQueryable of entities of type T.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Asynchronously deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to be deleted.</param>
        Task Delete(T entity);

        /// <summary>
        /// Asynchronously updates an entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        Task<T> Update(T entity);
    }
}
