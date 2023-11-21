using AmazingSales.Domain.Common;

namespace AmazingSales.Domain.Entities.ProfileEntities
{
    public sealed class ProfessionalProfile : BaseAuditableEntity
    {
        public Profile? Profile { get; private set; }
        public string AboutCompany { get; private set; }
        public string ShortDescription { get; private set; }
        public Address? Address { get; private set; }
        public ICollection<ProfessionalProfileImage> ImagesUrl { get; private set; }
        public ProfessionalProfile(
            Profile? profile,
            string? aboutCompany,
            string? shortDescription,
            Address? address,
            ICollection<ProfessionalProfileImage>? imagesUrl = null)
        {
            Profile = profile;
            AboutCompany = aboutCompany ?? string.Empty;
            ShortDescription = shortDescription ?? string.Empty;
            Address = address;
            ImagesUrl = imagesUrl ?? new List<ProfessionalProfileImage>();
        }
    }
}
