using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class CommentNotification:Notification
    {
        public Guid CommentedBy { get; set; }
        public CommentNotification(Guid commentedBy) : base("Comment")
        {
            this.CommentedBy = commentedBy;
        }

        public void AddMessage(string message)
        {
            this.Message = message;
        }

        public override string GetMessage()
        {
            return $"this Id : {CommentedBy} commented on your tweet ";
        }
    }
}
