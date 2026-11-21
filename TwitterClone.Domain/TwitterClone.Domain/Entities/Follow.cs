using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Follow:EntityBase
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
        public Follow(Guid followerId, Guid followingId):base(Guid.NewGuid())
        {
            this.FollowerId = followerId;
            this.FollowingId = followingId;
        }
    }
}
