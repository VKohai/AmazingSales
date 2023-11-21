using AmazingSales.Domain.Common;

namespace AmazingSales.Domain.Entities.ProfileEntities
{
    public sealed class ProfessionalProfileImage : BaseAuditableEntity
    {
        public string ImageUrl { get; private set; }
        public ProfessionalProfile ProfessionalProfile { get; private set; }
        public ProfessionalProfileImage(
            long id,
            string imageUrl,
            ProfessionalProfile professionalProfile
        )
        {
            Id = id;
            ImageUrl = imageUrl;
            ProfessionalProfile = professionalProfile;
        }
    }
}
