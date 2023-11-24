using AmazingSales.Domain.Enums;
using AmazingSales.Domain.Entities.AnnouncementEntities;

namespace AmazingSales.Application.Interfaces.Repositories;

public interface IAnnouncementRepository : IGenericRepository<Announcement, long>
{
    Task<IQueryable<Announcement>> GetAnnouncementsByCategory(Category category);
    Task<IQueryable<Announcement>> GetAnnouncementsByType(AnnouncementTypes announcementTypes);
}