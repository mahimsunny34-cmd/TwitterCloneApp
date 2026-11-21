using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class LikeService : ILikeService
    {
        public ILikeRepository _likeRepo;
        public IUserRepository _userRepo;
        public LikeService(ILikeRepository likeRepo,IUserRepository ur)
        {
            _likeRepo = likeRepo;
            _userRepo = ur;
        }
        public ReadLikeDto? AddLike(CreateLikeDto like)
        {
            if(like.LikedByUserId==Guid.Empty || like.TweetId == Guid.Empty)
            {
                return null;
            }

            var userExists = _userRepo.GetUserById(like.LikedByUserId);
            if (userExists == null)
            {
                return null;
            }

            var newLike = new Like(like.LikedByUserId, like.TweetId);
            var addLike = _likeRepo.AddLike(newLike);
            return new ReadLikeDto
            {
                LikedByUserId = addLike.LikedByUserId,
                TweetId = addLike.TweetId
            };
        }

        public bool DeleteLike(Guid id)
        {
            var likeExists = _likeRepo.GetLikeById(id);
            if (likeExists == null)
            {
                return false;
            }
            var deleteLike = _likeRepo.RemoveLike(id);
            return true;
        }
        public List<ReadLikeDto> GetAllLikes(Guid? userId, Guid? tweetId)
        {
            var likes = _likeRepo.GetLikes(userId, tweetId);
            return likes.Select(l => new ReadLikeDto
            {
                LikedByUserId=l.LikedByUserId,
                TweetId=l.TweetId
            }).ToList();
        }
        public ReadLikeDto? LikeById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            var like = _likeRepo.GetLikeById(id);
            return new ReadLikeDto
            {
                LikedByUserId = like.LikedByUserId,
                TweetId = like.TweetId
            };
        }
    }
}
