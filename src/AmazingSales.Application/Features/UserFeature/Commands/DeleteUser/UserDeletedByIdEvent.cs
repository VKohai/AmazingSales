using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities;

namespace AmazingSales.Application.Features.UserFeature.Commands
{
    public class UserDeletedByIdEvent : BaseEvent
    {
        public User? User { get; }

        public UserDeletedByIdEvent(User? user)
        {
            User = user;
        }
    }
}
