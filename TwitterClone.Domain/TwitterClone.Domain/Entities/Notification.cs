using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public abstract class Notification: EntityBase
    {
        public Guid UserId { get; set; }
        protected string Message { get; set; }
        public string NotificationType { get;  set; }
        public Guid TweetId { get; set; }
        public bool IsRead { get; set; }

        public Notification(string notificationType):base(Guid.NewGuid())
        {
            this.NotificationType = notificationType;
        }

        public string PrintNotification()
        {
            return $"receiver id {UserId} \n Message is {Message} \n Notification Type is {NotificationType} Tweet {TweetId} ";
        }

        public abstract string GetMessage();  
    }
}
