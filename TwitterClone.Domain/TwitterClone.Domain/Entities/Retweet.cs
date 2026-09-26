using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Retweet:EntityBase
    {
        public Guid ReTweetedByUserId { get; set; }
        public Guid OrginalTweetId { get; set; }
        public Retweet(Guid RetweetedByUserId, Guid OrginalTweetId) : base(Guid.NewGuid())
        {
            this.ReTweetedByUserId = RetweetedByUserId;
            this.OrginalTweetId = OrginalTweetId;
        }
    }
}
