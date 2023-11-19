namespace AmazingSales.Domain.Common.Interfaces
{
    /// <summary>
    /// IAuditableEntity adds additional properties to keep track of the entity’s audit trail information.
    /// </summary>
    public interface IAuditableEntity : IEntity
    {
        int? CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        int? UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
