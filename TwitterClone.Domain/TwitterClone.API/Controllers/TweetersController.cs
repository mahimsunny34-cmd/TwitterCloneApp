using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetersController : TwitterBaseController
    {
        public readonly IConfiguration _config;
        public TweetersController(IConfiguration config) 
        {
            _config = config;
        }
        public void GetTweet()
        {
            var connectionString=_config.GetValue<string>("logging:LogLevel:Default");
            var tweetsLength=_config.GetValue<int>("TwitterSettings:MaxTweetLength");
        }

        

        [HttpGet]  // /api/tweeters
        public IActionResult GetTweets()
        {
            var tweets = new List<Tweet>
            {
                new Tweet("my first tweet", Guid.NewGuid()),
                new Tweet("Hello, world!", Guid.NewGuid())
            };
            return Ok(tweets);
        }

        [HttpPost]  // /api/tweeters
        public IActionResult CreateTweets()
        {
            var newTweet=new Tweet("This is my first tweet!", Guid.NewGuid());
            return Ok(newTweet);
        }

        [HttpPut("{id}")]  // /api/tweeters/{id}
        public IActionResult UpdateTweet([FromRoute] Guid id)
        {
            return Ok("tweet updated");
        }

        [HttpDelete("{id}")]  // /api/tweeters/{id}
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            return Ok("tweet deleted");
        }

    }
    public class TwitterBaseController : ControllerBase
    {
       
    }
}
