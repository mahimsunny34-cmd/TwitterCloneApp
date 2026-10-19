using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos
{
    public class ReadBookmarkDto
    {
        public Guid AuthorId { get; set; }
        public Guid TweetId { get; set; }
    }
}
