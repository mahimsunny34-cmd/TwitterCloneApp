using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastratcure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly List<Like> _likeRepository = new List<Like>();
        public Like AddLike(Like like)
        {
           _likeRepository.Add(like);
            return like;
        }

        public Like GetLikeById(Guid id)
        {
            var likeExists = _likeRepository.SingleOrDefault(l => l.Id == id);
            return likeExists;
        }

        public List<Like> GetLikes(Guid? userId, Guid? tweetId)
        {
            var likes = _likeRepository;
            if (userId != null)
            {
                likes = likes.Where(l => l.LikedByUserId == userId).ToList();
            }

            if (tweetId != null)
            {
                likes = likes.Where(l => l.TweetId == tweetId).ToList();
            }

            return likes;
        }

        public bool RemoveLike(Guid id)
        {
            var deletedLike = _likeRepository.RemoveAll(l => l.Id == id);
            if (deletedLike==null)
            {
                return false;
            }
            return true;
        }
    }
}
