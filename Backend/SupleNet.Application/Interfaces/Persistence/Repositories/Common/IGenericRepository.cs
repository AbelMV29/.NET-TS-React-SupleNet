namespace SupleNet.Application.Interfaces.Persistence.Repositories.Common
{
    public interface IGenericRepository<T> where T :class
    {
        Task<T?> GetAsync(Guid id);
        Task<T?> GetReadOnlyAsync(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllReadOnly();
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
