using AmazingSales.Domain.Common;

namespace AmazingSales.Domain.Entities.AnnouncementEntities
{
    public sealed class Category : BaseAuditableEntity
    {
        public Category Parent { get; private set; }
        public string Name { get; private set; }
        public Category(string name, Category parent)
        {
            Name = name;
            Parent = parent;
        }
    }
}
