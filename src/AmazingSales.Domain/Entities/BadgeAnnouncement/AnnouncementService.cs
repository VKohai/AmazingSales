using AmazingSales.Domain.Entities.Enums;

namespace AmazingSales.Domain.Entities.BadgeAnnouncement
{
    public class AnnouncementService
    {
        public Announcement Announcement { get; private set; }
        public bool IsStartingPrice { get; private set; }
        public PaymentPer PaymentPer { get; private set; }
        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public WorkDays WorkDays { get; private set; }
        public AnnouncementService(
            Announcement announcement,
            PaymentPer? payment,
            DateTime? startTime,
            DateTime? endTime,
            WorkDays workDays,
            bool isStartingPrice = false
        )
        {
            Announcement = announcement;
            IsStartingPrice = isStartingPrice;
            PaymentPer = payment ?? PaymentPer.Service;
            StartTime = startTime;
            EndTime = endTime;
            WorkDays = workDays;
        }
    }
}
