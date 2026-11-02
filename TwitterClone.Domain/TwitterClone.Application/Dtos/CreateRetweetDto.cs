using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos
{
    public class CreateRetweetDto
    {
        public Guid ReTweetedByUserId { get; set; }
        public Guid OrginalTweetId { get; set; }

        // Optional: a retweet without a comment is a plain retweet.
        public string? Content { get; set; }

    }
}
