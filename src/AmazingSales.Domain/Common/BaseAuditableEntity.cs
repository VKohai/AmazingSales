using AmazingSales.Domain.Common.Interfaces;

namespace AmazingSales.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
    {
        protected BaseAuditableEntity(long id) : base(id)
        { }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
