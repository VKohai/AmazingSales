using AmazingSales.Domain.Enums;

namespace AmazingSales.Domain.Entities.AnnouncementEntities
{
    public sealed record AnnouncementProduct
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

        public AnnouncementProduct()
        {
        }
    }
}