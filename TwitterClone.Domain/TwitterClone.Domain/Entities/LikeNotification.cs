using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class LikeNotification:Notification
    {
        public Guid LikeByOtherId { get; set; }
        public LikeNotification(Guid likeByOtherId) : base("Like")
        {
            LikeByOtherId = likeByOtherId;
        }
    }
}
