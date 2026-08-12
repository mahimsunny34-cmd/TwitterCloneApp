using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Retweet:EntityBase
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public Guid OrginalTweetId { get; }
        public Guid TweetId { get; }
        public Retweet(Guid userId, Guid orginalTweetId, Guid tweetId)
        {
            this.Id = Guid.NewGuid();
            this.UserId = userId;
            this.OrginalTweetId = orginalTweetId;
            this.TweetId = tweetId;
        }
    }
}
