using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweeterController : ControllerBase
    {
        IConfiguration _config;
        public TweeterController(IConfiguration config)
        {
            _config = config;
        }
        public void GetTweet()
        {
            var connectionString=_config.GetValue<string>("logging:LogLevel:Default");
            var tweetsLength=_config.GetValue<int>("TwitterSettings:MaxTweetLength");
        }

        

        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = new List<Tweet>
            {
                new Tweet("my first tweet", Guid.NewGuid()),
                new Tweet("Hello, world!", Guid.NewGuid())
            };
            return Ok(tweets);
        }
    }
}
