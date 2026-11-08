using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IFollowService
    {
        public FollowDto? AddFollow(FollowDto followDto);
        public List<FollowDto> ShowFollowers(Guid userId);
        public FollowDto? GetFollowById(Guid id);
        public List<FollowDto> ShowAllFollowing(Guid userId);
        public FollowDto CreateFollow(FollowDto followDto);
        public bool DeleteFollow(Guid id);
    }
}
