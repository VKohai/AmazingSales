using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Infrastructure.Repositories;

public class GenericRepository<T, TKey> : IGenericRepository<T, TKey>
{
    public IQueryable<T> Entities { get; }

    public Task<T> GetByIdAsync(TKey id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> AddAsync(T item)
    {
        throw new NotImplementedException();
    }

    public Task<T?> DeleteByIdAsync(TKey id)
    {
        throw new NotImplementedException();
    }

    public Task<T?> UpdateAsync(T item)
    {
        throw new NotImplementedException();
    }
}