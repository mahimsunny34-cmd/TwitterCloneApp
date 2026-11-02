using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastratcure.Repositories
{
    public class RetweetRepository : IRetweetRepository
    {
        private readonly List<Retweet> _retweets = new List<Retweet>();
        public Retweet AddReTweet(Retweet retweet)
        {
            _retweets.Add(retweet);
            return retweet;
        }

        public List<Retweet> GetRetweets()
        {
            return _retweets;
        }

        public Retweet? GetRetweetById(Guid id)
        {
            var retweetExists = _retweets.SingleOrDefault(r => r.Id == id);
            if (retweetExists == null)
            {
                return null;
            }
            return retweetExists;
        }

        public Retweet? UpdateReTweet(Retweet retweet)
        { 
            _retweets.RemoveAll(r=>r.Id == retweet.Id);
            _retweets.Add(retweet);
            return retweet;
        }

        public bool DeleteReTweet(Retweet retweet)
        {
            return _retweets.Remove(retweet);
        }
    }
}
