using AmazingSales.Domain.Common;

namespace AmazingSales.Domain.Entities.BadgeAnnouncement
{
    public sealed class Category : BaseEntity
    {
        public Category Parent { get; private set; }
        public string Name { get; private set; }
        public Category(long id, string name, Category parent) : base(id)
        {
            Name = name;
            Parent = parent;
        }
    }
}
