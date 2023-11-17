using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.Enums;
using AmazingSales.Domain.Entities.BadgeAnnouncement;

namespace AmazingSales.Domain.Entities.ValueObjects
{
    public sealed record AnnouncementService : ValueObject
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Announcement;
            yield return IsStartingPrice;
            yield return PaymentPer;
            yield return StartTime!;
            yield return EndTime!;
            yield return WorkDays;
        }

    }
}
