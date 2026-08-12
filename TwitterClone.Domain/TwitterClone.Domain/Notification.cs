using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Domain
{
    public class Notification: EntityBase
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string NotificationType { get;  set; }
        public Guid TweetId { get; set; }
        public bool IsRead { get; set; }

        public Notification(string notificationType):base(Guid.NewGuid())
        {
            this.NotificationType = notificationType;
        }   
    }
}
