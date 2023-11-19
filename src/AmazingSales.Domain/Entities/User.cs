using AmazingSales.Domain.Common;

namespace AmazingSales.Domain.Entities
{
    public sealed class User : BaseAuditableEntity
    {
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public User(long id, string name, string phone, string? email) : base(id)
        {
            Name = name;
            Phone = phone;
            Email = email ?? string.Empty;
        }
    }
}
