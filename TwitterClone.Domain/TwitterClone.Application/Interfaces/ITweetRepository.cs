using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{ 
    public interface ITweetRepository
    {
        Tweet AddTweet(Tweet tweet);
        Tweet? UpdateTweet(Tweet updateTweet);
        Tweet? DeleteTweet(Guid id);
        List<Tweet> ShowTweet();
        Tweet? GetTweetById(Guid id);
    }
}
