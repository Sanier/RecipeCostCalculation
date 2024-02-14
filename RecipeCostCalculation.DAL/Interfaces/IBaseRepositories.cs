namespace RecipeCostCalculation.DAL.Interfaces
{
    public interface IBaseRepositories<T>
    {
        Task Create(T entity);
        IQueryable<T> GetAll();
        Task Delete(T entity);
        Task<T> Update(T entity);
    }
}
