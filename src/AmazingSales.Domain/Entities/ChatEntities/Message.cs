using AmazingSales.Domain.Common;
using AmazingSales.Domain.Entities.ProfileEntities;

namespace AmazingSales.Domain.Entities.ChatEntities
{
    public sealed class Message : BaseAuditableEntity
    {
        public Chat Chat { get; private set; }
        public Profile Sender { get; private set; }
        public string MessageText { get; private set; }
        public string AttachmentUrl { get; private set; }
        public DateTime Created { get; private set; }

        public Message(
            Chat chat,
            Profile sender,
            string? messageText,
            string? attachmentUrl
        )
        {
            Chat = chat;
            Sender = sender;
            MessageText = messageText ?? string.Empty;
            AttachmentUrl = attachmentUrl ?? string.Empty;
            Created = DateTime.UtcNow;
        }
    }
}
