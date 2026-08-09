using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; }
        public Guid SenderId { get; }
        public Guid ReceiverId { get; }
        public string Content { get; set; }

        public Message(Guid senderId, Guid receiverId, string content)
        {
            this.Id = Guid.NewGuid();
            this.SenderId = senderId;
            this.ReceiverId = receiverId;
            this.Content = content;
        }
    }
}
