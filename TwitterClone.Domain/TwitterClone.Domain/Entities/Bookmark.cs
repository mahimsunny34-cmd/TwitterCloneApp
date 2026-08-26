using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Bookmark:EntityBase
    {
        
        public Guid TweetId { get; set; }
        public Guid UserId{ get; set; }

        public Bookmark(Guid TweetId,Guid UserId):base(Guid.NewGuid())
        {
            this.TweetId = TweetId;
            this.UserId = UserId;
        }
    }
}
