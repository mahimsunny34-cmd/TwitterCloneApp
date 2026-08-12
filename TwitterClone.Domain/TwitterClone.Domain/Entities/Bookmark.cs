using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Bookmark:EntityBase
    {
        public Guid Id { get; }
        public Guid TweetId {  get; }
        public Guid UserId{  get; }
        public DateTime CreatedAt { get; set; } 

        public Bookmark(Guid tweetId, Guid userId)
        {
            this.Id = Guid.NewGuid();
            this.TweetId = tweetId;
            this.UserId = userId;
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
