using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class RetweetService : IRetweetService
    {
        public IRetweetRepository _retweetRepository;
        public RetweetService(IRetweetRepository retweetRepository)
        {
            _retweetRepository = retweetRepository;
        }
        public List<ReadRetweetDto> GetRetweets()
        {
            var retweets = _retweetRepository.GetRetweets();
            var newRetweets = retweets.Select(r => new ReadRetweetDto
            {
                ReTweetedByUserId = r.ReTweetedByUserId,
                OrginalTweetId = r.OrginalTweetId,
                Content = r.Content
            }).ToList();
            return newRetweets;
        }

        public ReadRetweetDto? CreateRetweet(CreateRetweetDto createRetweetDto)
        {
            if (string.IsNullOrWhiteSpace(createRetweetDto.Content) ||
                createRetweetDto.ReTweetedByUserId == Guid.Empty ||
                createRetweetDto.OrginalTweetId == Guid.Empty)
            {
                return null;
            }

            var newRetweet=new Retweet(createRetweetDto.ReTweetedByUserId, createRetweetDto.OrginalTweetId, createRetweetDto.Content);
            var createdRetweet = _retweetRepository.AddReTweet(newRetweet);
            var readNewReTweet=new ReadRetweetDto
            {
                ReTweetedByUserId = createdRetweet.ReTweetedByUserId,
                OrginalTweetId = createdRetweet.OrginalTweetId,
                Content = createdRetweet.Content
            };
            return readNewReTweet;
        }

        public ReadRetweetDto? GetRetweetById(Guid id)
        {
            var retweet = _retweetRepository.GetRetweetById(id);
            if (retweet == null)
            {
                return null;
            }
            var readRetweet = new ReadRetweetDto
            {
                ReTweetedByUserId = retweet.ReTweetedByUserId,
                OrginalTweetId = retweet.OrginalTweetId,
                Content = retweet.Content
            };
            return readRetweet;
        }

        public ReadRetweetDto? UpdateRetweet(Guid id,UpdateRetweetDto dto)
        {
            if(Guid.Empty==id || string.IsNullOrWhiteSpace(dto.Content))
            {
                return null;
            }
            var retweetExists=_retweetRepository.GetRetweetById(id);
            if(retweetExists == null)
            {
                return null;
            }
            retweetExists.Content= dto.Content;
            var updatedRetweet = _retweetRepository.UpdateReTweet(retweetExists);
            var readUpdatedRetweet = new ReadRetweetDto
            {
                ReTweetedByUserId = updatedRetweet.ReTweetedByUserId,
                OrginalTweetId = updatedRetweet.OrginalTweetId,
                Content = updatedRetweet.Content
            };
            return readUpdatedRetweet;
        }

        public bool DeleteRetweet(Guid id)
        {
            if (id == Guid.Empty)
            {
                return false;
            }
            var retweetExists = _retweetRepository.GetRetweetById(id);
            if (retweetExists == null)
            {
                return false;
            }
            return _retweetRepository.DeleteReTweet(retweetExists);
        }
    }
}

