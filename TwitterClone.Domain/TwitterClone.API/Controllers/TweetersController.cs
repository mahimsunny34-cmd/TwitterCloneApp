using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetersController : TwitterBaseController
    {
        public readonly IConfiguration _config;
        public ITweetService _tweetService;
        public TweetersController(IConfiguration config,TweetRepository tweetRepo,ITweetService tweetService) 
        {
            _config = config;
            _tweetService = tweetService;
        }
        public void GetTweet()
        {
            var connectionString=_config.GetValue<string>("logging:LogLevel:Default");
            var tweetsLength=_config.GetValue<int>("TwitterSettings:MaxTweetLength");
        }

        

        [HttpGet]  // /api/tweeters
        public IActionResult GetTweets()
        {
            var tweets = _tweetService.GetTweets();
            if(tweets == null)
            {
                return NotFound("No tweets found.");
            }   
            return Ok(tweets);
        }

        [HttpGet("{id}")]  // /api/tweeters/{id}
        public IActionResult GetTweetById(Guid id)
        {
            var tweet=_tweetService.GetTweetById(id);
            if(tweet == null)
            {
                return NotFound("Tweet not found.");
            }
            return Ok(tweet);
        }

        [HttpPost]  // /api/tweeters
        public IActionResult CreateTweets(CreateTweetDto tweetDto)
        {
            var tweet = _tweetService.CreateTweets(tweetDto);
            if (tweet == null)
            {
                return BadRequest("Failed to create tweet.");
            }
            return Ok(tweet);
        }

        [HttpPut("{id}")]  // /api/tweeters/{id}
        public IActionResult UpdateTweet([FromRoute] Guid id,UpdateTweetDto updateDto)
        {
            var updatedTweet = _tweetService.UpdateTweet(id, updateDto);
            if (updatedTweet == null)
            {
                return NotFound("Tweet not found.");
            }
            return Ok(updatedTweet);
        }

        [HttpDelete("{id}")]  // /api/tweeters/{id}
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var deletedTweet = _tweetService.DeleteTweet(id);
            if (!deletedTweet)
            {
                return NotFound("Tweet not found.");
            }
            return Ok("Tweet deleted successfully.");
        }
    }
    public class TwitterBaseController : ControllerBase
    {
       
    }
}
