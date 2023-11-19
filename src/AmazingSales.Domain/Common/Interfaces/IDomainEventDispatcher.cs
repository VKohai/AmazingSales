namespace AmazingSales.Domain.Common.Interfaces
{
    /// <summary>
    /// IDomainEventDispatcher declares a method that can be used to dispatch domain events throughout the application.
    /// </summary>
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
    }
}
