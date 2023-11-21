using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.AnnouncementEntities;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands;

internal class AnnouncementCreatedEvent : BaseEvent
{
    private Announcement CreatedAnnouncement { get; }

    public AnnouncementCreatedEvent(Announcement createdAnnouncement)
    {
        CreatedAnnouncement = createdAnnouncement;
    }
}