using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeRepository
    {
        Like AddLike(Like like);
        List<Like> GetLikes(Guid? userId, Guid? tweetId);
        bool RemoveLike(Guid id);
        Like GetLikeById(Guid id);

    }
}
