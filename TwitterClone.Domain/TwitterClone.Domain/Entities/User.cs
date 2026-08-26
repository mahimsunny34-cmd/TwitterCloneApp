using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class User:EntityBase,IFollowable,INotifiable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<Guid> _followers=new List<Guid>();
        public List<Guid> _incomingNotifications=new List<Guid>();

        public User() : base(Guid.NewGuid())
        {
        }

        public void Follow(Guid userId)
        {
            if (!_followers.Contains(userId))
            {
                _followers.Add(userId);
            }
        }

        public void Unfollow(Guid userId)
        {
            if (_followers.Contains(userId))
            {
                _followers.Remove(userId);
            }
        }

        public void AddNotification(Guid notificationId)
        {
            if (!_incomingNotifications.Contains(notificationId))
            {
                _incomingNotifications.Add(notificationId);
            }
        }
    }
}
