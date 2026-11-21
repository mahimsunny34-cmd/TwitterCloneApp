using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Like:EntityBase
    {
        public Guid LikedByUserId { get; set; }
        public Guid TweetId { get; set; }
        public Like(Guid userId, Guid tweetId):base(Guid.NewGuid())
        {
            LikedByUserId = userId;
            TweetId = tweetId;
        }
    }
}
