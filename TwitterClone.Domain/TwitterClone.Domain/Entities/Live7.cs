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
            likeNotification.AddMessage("You have a new like!");

            CommentNotification commentNotification = new CommentNotification(Guid.NewGuid());
            commentNotification.AddMessage("You have a new comment!");

            SystemNotification systemNotification = new SystemNotification("There is a system update available.");
            systemNotification.AddMessage("This is a system notification.");

            FriendRequestNotification friendRequestNotification = new FriendRequestNotification(Guid.NewGuid());
            friendRequestNotification.AddMessage("You have a new friend request!");

            var description = likeNotification.DescribeRecord();
            Console.WriteLine(description);
        }
    }
}
