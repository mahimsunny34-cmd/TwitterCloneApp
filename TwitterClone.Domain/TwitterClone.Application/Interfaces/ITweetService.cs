using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetService
    {
        List<ReadTweetDto> GetTweets();
        ReadTweetDto? GetTweetById(Guid id);
        ReadTweetDto? CreateTweets(CreateTweetDto tweetDto);
        ReadTweetDto? UpdateTweet(Guid id, UpdateTweetDto updateDto);
        bool DeleteTweet(Guid id);
    }
}
