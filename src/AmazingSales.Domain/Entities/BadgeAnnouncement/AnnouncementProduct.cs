namespace AmazingSales.Domain.Entities.BadgeAnnouncement
{
    public sealed class AnnouncementProduct
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
    }

    public enum ProductStatus
    {
        Fresh, Used
    }

    public enum ProductSellingType
    {
        SellingMine, PurchasedForSale
    }
}
