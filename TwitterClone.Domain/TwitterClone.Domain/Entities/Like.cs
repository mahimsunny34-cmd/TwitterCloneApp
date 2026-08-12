using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Like:EntityBase
    {
        public Guid UserId { get; }
        public Guid TweetId { get; }
        public DateTime LikedAt { get; } 
        public Like(Guid userId, Guid tweetId)
        {
            UserId = userId;
            TweetId = tweetId;
            LikedAt = DateTime.UtcNow;
        }
    }
}
