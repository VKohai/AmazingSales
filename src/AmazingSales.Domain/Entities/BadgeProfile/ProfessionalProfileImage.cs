using AmazingSales.Domain.Common;

namespace AmazingSales.Domain.Entities.BadgeProfile
{
    public sealed class ProfessionalProfileImage : BaseEntity
    {
        public string ImageUrl { get; private set; }
        public ProfessionalProfile ProfessionalProfile { get; private set; }
        public ProfessionalProfileImage(
            long id,
            string imageUrl,
            ProfessionalProfile professionalProfile
        ) : base(id)
        {
            ImageUrl = imageUrl;
            ProfessionalProfile = professionalProfile;
        }
    }
}
