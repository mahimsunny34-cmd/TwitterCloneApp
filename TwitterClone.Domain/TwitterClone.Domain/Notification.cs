using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TwitterClone.Domain
{
    public class Notification
    {
        public Guid Id { get; }
        public Guid ReceiverId{  get; }
        public Guid ActorId {  get; }
        public string NotificationType { get;  set; }
        public Guid TweetId { get; }

        public Notification(Guid receiverId, Guid actorId, string notificationType, Guid tweetId)
        {
            this.Id = Guid.NewGuid();
            this.ReceiverId = receiverId;
            this.ActorId = actorId;
            this.NotificationType = notificationType;
            this.TweetId = tweetId;
        }
    }
}
