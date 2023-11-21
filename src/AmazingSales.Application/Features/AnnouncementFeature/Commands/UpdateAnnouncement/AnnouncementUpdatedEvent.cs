using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.AnnouncementEntities;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands.UpdateAnnouncement;

public class AnnouncementUpdatedEvent : BaseEvent
{
    public Announcement Announcement { get; }

    public AnnouncementUpdatedEvent(Announcement updatedAnnouncement)
    {
        Announcement = updatedAnnouncement;
    }
}