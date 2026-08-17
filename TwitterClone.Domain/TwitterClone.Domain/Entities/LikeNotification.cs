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

        public void AddMessage(string message)
        {
            this.Message = message;
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, LikeByOtherId: {LikeByOtherId} ,IsRead: {IsRead}";
        }

        public override string GetMessage()
        {
            return $"user with Id: {LikeByOtherId} liked your tweet";
        }
    }
}
