using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeService
    {
        ReadLikeDto AddLike(CreateLikeDto like);
        List<ReadLikeDto> GetAllLikes(Guid? userId, Guid? tweetId);
        ReadLikeDto LikeById(Guid id);
        bool DeleteLike(Guid id);
    }
}
