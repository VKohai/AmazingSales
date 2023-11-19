namespace AmazingSales.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T, TKey>
    {
        Task<T> GetByIdAsync(TKey id);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task<T?> DeleteByIdAsync(TKey id);
        Task<T?> UpdateByIdAsync(TKey id);
    }
}
