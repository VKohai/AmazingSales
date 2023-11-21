using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.BadgeAnnouncement;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands.UpdateAnnouncement;

public class AnnouncementUpdatedByIdEvent : BaseEvent
{
    public Announcement Announcement { get; }

    public AnnouncementUpdatedByIdEvent(Announcement updatedAnnouncement)
    {
        Announcement = updatedAnnouncement;
    }
}