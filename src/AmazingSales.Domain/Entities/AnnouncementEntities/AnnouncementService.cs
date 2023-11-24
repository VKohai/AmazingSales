using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.Enums;

namespace AmazingSales.Domain.Entities.AnnouncementEntities
{
    public sealed class AnnouncementService : AnnouncementType
    {
        public Announcement Announcement { get; private set; }
        public bool IsStartingPrice { get; private set; }
        public PaymentPer PaymentPer { get; private set; }
        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public WorkDays WorkDays { get; private set; }

        public AnnouncementService(
            Announcement announcement,
            PaymentPer? paymentPer,
            DateTime? startTime,
            DateTime? endTime,
            WorkDays workDays,
            bool isStartingPrice = false
        )
        {
            Announcement = announcement;
            IsStartingPrice = isStartingPrice;
            PaymentPer = paymentPer ?? PaymentPer.Service;
            StartTime = startTime;
            EndTime = endTime;
            WorkDays = workDays;
        }

        public AnnouncementService()
        {
        }
    }
}