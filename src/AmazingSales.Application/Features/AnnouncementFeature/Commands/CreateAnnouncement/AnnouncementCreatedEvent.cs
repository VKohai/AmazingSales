using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.BadgeAnnouncement;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands;

internal class AnnouncementCreatedEvent : BaseEvent
{
    private Announcement CreatedAnnouncement { get; }

    public AnnouncementCreatedEvent(Announcement createdAnnouncement)
    {
        CreatedAnnouncement = createdAnnouncement;
    }
}