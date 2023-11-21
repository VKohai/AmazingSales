using AmazingSales.Domain.Entities.BadgeProfile;
using AmazingSales.Domain.Entities.BadgeAnnouncement;

namespace AmazingSales.Domain.ValueObjects
{
    public sealed record Bookmark
    {
        public Profile Profile { get; private set; }
        public Announcement Announcement { get; private set; }

        public Bookmark(Profile profile, Announcement announcement)
        {
            Profile = profile;
            Announcement = announcement;
        }
    }
}