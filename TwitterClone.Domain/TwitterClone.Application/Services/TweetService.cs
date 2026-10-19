using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepo;
        public TweetService(ITweetRepository tweetRepo)
        {
            _tweetRepo = tweetRepo;
        }
        public List<ReadTweetDto> GetTweets()
        {
            var tweets = _tweetRepo.ShowTweet();
            var tweetsList = tweets.Select(t => new ReadTweetDto
            {
                AuthorId = t.AuthorId,
                Content = t.Content
            }).ToList();
            return tweetsList;
        }

        public ReadTweetDto? GetTweetById(Guid id)
        {
            var tweet = _tweetRepo.GetTweetById(id);
            if (tweet == null)
            {
                return null;
            }
            var readTweet=new ReadTweetDto
            {
                AuthorId = tweet.AuthorId,
                Content = tweet.Content
            };
            return readTweet;
        }

        public ReadTweetDto? CreateTweets(CreateTweetDto tweetDto)
        {
            if (tweetDto.AuthorId == Guid.Empty || string.IsNullOrEmpty(tweetDto.Content))
            {
                return null;
            }
            var tweet = new Tweet(tweetDto.Content, tweetDto.AuthorId);
            _tweetRepo.AddTweet(tweet);
            var readTweet=new ReadTweetDto
            {
                AuthorId = tweet.AuthorId,
                Content = tweet.Content
            };
            return readTweet;
        }

        public ReadTweetDto? UpdateTweet(Guid id,UpdateTweetDto updateDto)
        {
            if(Guid.Empty==id || string.IsNullOrWhiteSpace(updateDto.Content))
            {
                return null;
            };

            var tweetExists = _tweetRepo.GetTweetById(id);
            if (tweetExists == null)
            {
                return null;
            }
            tweetExists.Content = updateDto.Content;
            var updateTweet= _tweetRepo.UpdateTweet(tweetExists);
            var ReadTweet = new ReadTweetDto
            {
                AuthorId = updateTweet.AuthorId,
                Content = updateTweet.Content
            };
            return ReadTweet;
        }

        public bool DeleteTweet(Guid id)
        {
            var tweetToDelete = _tweetRepo.DeleteTweet(id);
            if(tweetToDelete == null)
            {
                return false;
            }
            return true;
        }
    }
}
