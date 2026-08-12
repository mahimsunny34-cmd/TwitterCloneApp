using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class FriendRequestNotification:Notification 
    {
        public Guid RequestedBy { get; set; }
        public FriendRequestNotification(Guid requestedBy) : base("FriendRequest")
        {
            this.RequestedBy = requestedBy;
        }
    }
}
