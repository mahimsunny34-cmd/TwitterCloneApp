using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Follow:EntityBase
    {
        public Guid FollowerId { get; }
        public Guid FollowingId { get; }
        public Follow(Guid followerId, Guid followingId):base(Guid.NewGuid())
        {
            this.FollowerId = followerId;
            this.FollowingId = followingId;
        }
    }
}
