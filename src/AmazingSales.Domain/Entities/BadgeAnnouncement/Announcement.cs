using AmazingSales.Domain.Enums;
using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.BadgeProfile;

namespace AmazingSales.Domain.Entities.BadgeAnnouncement
{
    public sealed class Announcement : BaseEntity
    {
        public string Header { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public bool Autopublishing { get; private set; }
        public DateTime Created { get; private set; }
        public PublicationStatus PublicationStatus { get; private set; }
        public int Views { get; private set; }
        public Category Category { get; private set; }
        public Profile Profile { get; private set; }
        public Address Address { get; private set; }
        public AnnouncementType AnnouncementType { get; private set; }
        public ContactMethod ContactMethod { get; private set; }
        public Announcement(
            long id,
            string header,
            string description,
            decimal price,
            bool? autopublishing,
            DateTime? created,
            PublicationStatus? publicationStatus,
            int views,
            Category category,
            Profile profile,
            Address address,
            AnnouncementType announcementType,
            ContactMethod? contactMethod) : base(id)
        {
            Header = header;
            Description = description;
            Price = price;
            Autopublishing = autopublishing ?? true;
            Created = created ?? DateTime.Now;
            PublicationStatus = publicationStatus ?? PublicationStatus.Draft;
            Views = views;
            Category = category;
            Profile = profile;
            Address = address;
            AnnouncementType = announcementType;
            ContactMethod = contactMethod ?? ContactMethod.MessagesAndCalls;
        }
    }
}