using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.BadgeAnnouncement;
using AmazingSales.Domain.Entities.BadgeProfile;

namespace AmazingSales.Domain.Entities.BadgeChat
{
    public sealed class Chat : BaseAuditableEntity
    {
        public Profile Seller { get; private set; }
        public Profile Customer { get; private set; }
        public Announcement Announcement { get; private set; }
        public DateTime Created { get; private set; }

        public Chat(
            long id,
            Profile seller,
            Profile customer,
            Announcement announcement
        ) : base(id)
        {
            Seller = seller;
            Customer = customer;
            Announcement = announcement;
            Created = DateTime.UtcNow;
        }
    }
}
