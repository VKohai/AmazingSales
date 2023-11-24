using AmazingSales.Domain.Entities.AnnouncementEntities;

namespace AmazingSales.Application.Interfaces.Repositories;

public interface ICategoryRepository : IGenericRepository<Category, long>
{
    Task<IEnumerable<Category>> GetCategoriesByParentId(long id);
}