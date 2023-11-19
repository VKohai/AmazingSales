using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities;

namespace AmazingSales.Application.Features.UserFeature.Commands.UpdateUser
{
    public class UserUpdatedByIdEvent : BaseEvent
    {
        public User? User { get; }

        public UserUpdatedByIdEvent(User? user)
        {
            User = user;
        }
    }
}
