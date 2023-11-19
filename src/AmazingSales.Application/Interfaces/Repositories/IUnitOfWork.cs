namespace AmazingSales.Application.Interfaces.Repositories
{
    /// <summary>
    /// IUnitOfWork defines a unit of work pattern that allows us
    /// to save changes made by multiple repositories at once.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T, TKey> Repository<T, TKey>();
        Task<int> Save(CancellationToken cancellationToken);
        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        Task Rollback();
    }
}
