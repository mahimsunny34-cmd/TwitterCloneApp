using TwitterClone.Domain.Entities;
using TwitterClone.Application.Interfaces;
namespace TwitterClone.API.Data
{
    public class TweetRepository : ITweetRepository
    {
        private readonly List<Tweet> _tweets=new List<Tweet>();

        public Tweet AddTweet(Tweet tweet)
        {
            var tweetExists = _tweets.SingleOrDefault(t => t.Id == tweet.Id);
            if (tweetExists != null)
            {
                throw new InvalidOperationException("Tweet with the same ID already exists.");

            }
            else
            {
                _tweets.Add(tweet);
                return tweet;
            }
        }

        public Tweet? UpdateTweet(Tweet updateTweet)
        {
            _tweets.RemoveAll(t => t.Id == updateTweet.Id);
            _tweets.Add(updateTweet);
            return updateTweet;
        }

        public Tweet? DeleteTweet(Guid id)
        {
            var tweetToDelete = _tweets.SingleOrDefault(t => t.Id == id);
            if (tweetToDelete != null)
            {
                _tweets.Remove(tweetToDelete);
            }
            return tweetToDelete;
        }

        public List<Tweet> ShowTweet()
        {
            return _tweets;
        }

        public Tweet? GetTweetById(Guid id)
        {
            var tweetExists = _tweets.SingleOrDefault(t => t.Id == id);
            if(tweetExists != null)
            {
                return tweetExists;
            }
            else
            {
                return null;
            }
        }
    }
}
