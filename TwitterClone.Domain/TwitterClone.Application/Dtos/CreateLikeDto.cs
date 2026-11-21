using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos
{
    public class CreateLikeDto
    {
        public Guid LikedByUserId { get; set; }
        public Guid TweetId { get; set; }
    }
}
