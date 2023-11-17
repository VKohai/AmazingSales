using AmazingSales.Domain.Enums;
using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.BadgeAnnouncement;

namespace AmazingSales.Domain.ValueObjects
{
    public sealed record AnnouncementProduct : ValueObject
    {
        public Announcement Announcement { get; private set; }
        public int Amount { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductSellingType ProductSellingType { get; set; }
        public AnnouncementProduct(
            Announcement announcement,
            int amount,
            ProductStatus productStatus = ProductStatus.Fresh,
            ProductSellingType productSellingType = ProductSellingType.SellingMine
        )
        {
            Announcement = announcement;
            Amount = amount;
            ProductStatus = productStatus;
            ProductSellingType = productSellingType;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Announcement;
            yield return Amount;
            yield return ProductStatus;
            yield return ProductSellingType;
        }

    }
}
