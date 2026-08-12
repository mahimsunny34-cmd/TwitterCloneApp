using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class LikeNotification:Notification
    {
        public Guid LikeByOther { get; set; }
        public LikeNotification(Guid likeByOther) : base("Like")
        {
            LikeByOther = likeByOther;
        }
    }
}
