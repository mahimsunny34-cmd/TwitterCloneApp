using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos
{
    public class ReadRetweetDto
    {
        public Guid ReTweetedByUserId { get; set; }
        public Guid OrginalTweetId { get; set; }
        public string? Content { get; set; }
    }
}
