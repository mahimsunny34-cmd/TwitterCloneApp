using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Data
{
    public class TweetRepository
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

        public Tweet? UpdateTweet(Guid id, string content)
        {
            var existingTweet=_tweets.SingleOrDefault(t=> t.Id == id);
            if (existingTweet != null)
            {
                _tweets.Remove(existingTweet);
                _tweets.Add(new Tweet(content, existingTweet.AuthorId));
                return existingTweet;
            }
            else
            {
                return null;
            }
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
