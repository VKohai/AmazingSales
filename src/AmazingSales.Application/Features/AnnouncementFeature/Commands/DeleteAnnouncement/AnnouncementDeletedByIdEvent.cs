using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.AnnouncementEntities;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands;

internal class AnnouncementDeletedByIdEvent : BaseEvent
{
    public Announcement? Announcement { get; }

    public AnnouncementDeletedByIdEvent(Announcement? deletedAnnouncement)
    {
        Announcement = deletedAnnouncement;
    }
}