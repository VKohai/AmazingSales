using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.BadgeProfile;

namespace AmazingSales.Domain.Entities.BadgeChat
{
    public sealed class Message : BaseEntity
    {
        public Chat Chat { get; private set; }
        public Profile Sender { get; private set; }
        public string MessageText { get; private set; }
        public string AttachmentUrl { get; private set; }
        public DateTime Created { get; private set; }

        public Message(
            long id,
            Chat chat,
            Profile sender,
            string? messageText,
            string? attachmentUrl
        ) : base(id)
        {
            Chat = chat;
            Sender = sender;
            MessageText = messageText ?? string.Empty;
            AttachmentUrl = attachmentUrl ?? string.Empty;
            Created = DateTime.UtcNow;
        }
    }
}
