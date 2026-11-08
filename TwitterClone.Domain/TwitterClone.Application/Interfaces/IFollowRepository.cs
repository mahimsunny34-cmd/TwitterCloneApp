using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IFollowRepository
    {
        Follow? AddFollow(Follow follow);
        List<Follow> ShowAllFollows();
        Follow? GetFollowById(Guid id);
        List<Follow>? Followers(Guid id);
        List<Follow> Following(Guid userId);
        bool DeleteFollow(Guid id);
    }
}
