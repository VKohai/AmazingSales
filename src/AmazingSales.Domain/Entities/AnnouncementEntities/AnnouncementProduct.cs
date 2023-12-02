using AmazingSales.Domain.Enums;

namespace AmazingSales.Domain.Entities.AnnouncementEntities
{
    public sealed class AnnouncementProduct : AnnouncementType
    {
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

        public AnnouncementProduct()
        {
        }
    }
}