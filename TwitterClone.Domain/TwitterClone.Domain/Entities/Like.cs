using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Like:EntityBase
    {
        public Guid LikedByUserId { get; }
        public Guid TweetId { get; }
        public Like(Guid userId, Guid tweetId):base(Guid.NewGuid())
        {
            LikedByUserId = userId;
            TweetId = tweetId;
        }
    }
}
