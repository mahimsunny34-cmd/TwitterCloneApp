using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IRetweetRepository
    {
        Retweet AddReTweet(Retweet retweet);
        List<Retweet> GetRetweets();
        Retweet? GetRetweetById(Guid id);
        Retweet? UpdateReTweet(Retweet retweet);
        bool DeleteReTweet(Retweet retweet);
    }
}
