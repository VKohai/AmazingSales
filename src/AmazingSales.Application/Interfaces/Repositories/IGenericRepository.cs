namespace AmazingSales.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T, in TKey>
    {
        IQueryable<T> Entities { get; }
        Task<T> GetByIdAsync(TKey id);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task<T?> DeleteByIdAsync(TKey id);
        Task<T?> UpdateAsync(T item);
    }
}