using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Message:EntityBase
    {
        public Guid SenderId { get; }
        public Guid ReceiverId { get; }
        public string Content { get; set; }
        bool IsRead { get; set; }
        public DateTime SentAt { get; set; }
        public Message(Guid senderId, Guid receiverId, string content) : base(Guid.NewGuid())
        {
            this.SenderId = senderId;
            this.ReceiverId = receiverId;
            this.Content = content;
            this.IsRead = false;
            this.SentAt = DateTime.UtcNow;
        }
    }
}
