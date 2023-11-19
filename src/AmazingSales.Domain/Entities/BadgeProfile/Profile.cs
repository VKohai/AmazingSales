using AmazingSales.Domain.Enums;
using AmazingSales.Domain.Common;

namespace AmazingSales.Domain.Entities.BadgeProfile
{
    public sealed class Profile : BaseAuditableEntity
    {
        public decimal Rating { get; private set; }
        public string? MainImageUrl { get; private set; }
        public User User { get; private set; }
        public ProfileType ProfileType { get; private set; }

        public Profile(
            decimal rating,
            string? mainImageUrl,
            User user,
            ProfileType profileType
        )
        {
            Rating = rating;
            MainImageUrl = mainImageUrl ?? string.Empty;
            User = user;
            ProfileType = profileType;
        }
    }
}
