using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos
{
    public class FollowDto
    {
        public Guid FollowerId { get; set; }
        public Guid FollowingId { get; set; }
    }
}
