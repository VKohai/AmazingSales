using MediatR;

namespace AmazingSales.Domain.Common
{
    /// <summary>
    /// BaseEvent is the base class of all domain events throughout the application.
    /// </summary>
    public abstract class BaseEvent : INotification
    {
        /// <summary>
        /// Tells us when a particular event has occurred.
        /// </summary>
        public DateTime DateOccured { get; protected set; } = DateTime.UtcNow;
    }
}
