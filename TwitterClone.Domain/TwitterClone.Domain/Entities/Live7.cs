using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Live7
    {
        public static void Main(string[] args)
        {
            LikeNotification likeNotification = new LikeNotification(Guid.NewGuid());
            var description = likeNotification.DescribeRecord();
        }
    }
}
