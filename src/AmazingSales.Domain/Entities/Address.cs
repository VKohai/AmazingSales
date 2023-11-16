using AmazingSales.Domain.Common;

namespace AmazingSales.Domain.Entities
{
    public sealed class Address : BaseEntity
    {
        public string Country { get; private set; }
        public string Region { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string? House { get; private set; }
        public string? Apartement { get; private set; }
        public Address(
            long id,
            string country,
            string region,
            string city,
            string street,
            string? house,
            string? apartement) : base(id)
        {
            Country = country;
            Region = region;
            City = city;
            Street = street;
            House = house ?? string.Empty;
            Apartement = apartement ?? string.Empty;
        }
    }
}
