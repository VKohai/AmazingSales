using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities;

namespace AmazingSales.Application.Features.UserFeature.Commands
{
    public class UserCreatedEvent : BaseEvent
    {
        public User User { get; }

        public UserCreatedEvent(User user)
        {
            User = user;
        }
    }
}
