using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.AnnouncementEntities;
using AmazingSales.Domain.Entities.ProfileEntities;

namespace AmazingSales.Domain.Entities.ChatEntities
{
    public sealed class Chat : BaseAuditableEntity
    {
        public Profile Seller { get; private set; }
        public Profile Customer { get; private set; }
        public Announcement Announcement { get; private set; }
        public DateTime Created { get; private set; }

        public Chat(
            Profile seller,
            Profile customer,
            Announcement announcement
        )
        {
            Seller = seller;
            Customer = customer;
            Announcement = announcement;
            Created = DateTime.UtcNow;
        }
    }
}
