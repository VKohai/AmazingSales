using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities;

namespace AmazingSales.Application.Features.UserFeature.Commands
{
    public class UserUpdatedEvent : BaseEvent
    {
        public User? User { get; }

        public UserUpdatedEvent(User? user)
        {
            User = user;
        }
    }
}