using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TwitterClone.API.Data;
using TwitterClone.API.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TweetersController : TwitterBaseController
    {
        public readonly IConfiguration _config;
        public TweetRepository _tweetRepo;
        public TweetersController(IConfiguration config,TweetRepository tweetRepo) 
        {
            _config = config;
            _tweetRepo = tweetRepo;
        }
        public void GetTweet()
        {
            var connectionString=_config.GetValue<string>("logging:LogLevel:Default");
            var tweetsLength=_config.GetValue<int>("TwitterSettings:MaxTweetLength");
        }

        

        [HttpGet]  // /api/tweeters
        public IActionResult GetTweets()
        {
            var tweets = _tweetRepo.ShowTweet();
            var tweetsList = tweets.Select(t => new ReadTweetDto
            {
                AuthorId = t.AuthorId,
                Content = t.Content
            });
            return Ok(tweetsList);
        }

        [HttpGet("{id}")]  // /api/tweeters/{id}
        public IActionResult GetTweetById(Guid id)
        {
            var tweet = _tweetRepo.GetTweetById(id);
            if (tweet == null)
            {
                return NotFound();
            }
            else
            {
                var readTweet = new ReadTweetDto
                {
                    AuthorId = tweet.AuthorId,
                    Content = tweet.Content
                };
                return Ok(readTweet);
            }
        }

        [HttpPost]  // /api/tweeters
        public IActionResult CreateTweets(CreateTweetDto tweetDto)
        {
            if(tweetDto.AuthorId==Guid.Empty || string.IsNullOrEmpty(tweetDto.Content))
            {
                return BadRequest("AuthorId and Content are required.");
            }
            var tweet=new Tweet(tweetDto.Content, tweetDto.AuthorId);
            _tweetRepo.AddTweet(tweet);
            if(tweet== null)
            {
                return BadRequest("Tweet could not be created.");
            }
            else
            {
                var readTweet = new ReadTweetDto
                {
                    AuthorId = tweet.AuthorId,
                    Content = tweet.Content
                };
                return Ok(readTweet);
            }
        }

        [HttpPut("{id}")]  // /api/tweeters/{id}
        public IActionResult UpdateTweet([FromRoute] Guid id,UpdateTweetDto updateDto)
        {
            if(string.IsNullOrWhiteSpace(updateDto.Content) || Guid.Empty == id)
            {
                return BadRequest("Content and Id are required.");
            }

            var updatedTweet = _tweetRepo.UpdateTweet(id, updateDto.Content);
            if (updatedTweet == null)
            {
                return NotFound("Tweet not found.");
            }

            else
            {
                return Ok("tweet updated");
            }
        }

        [HttpDelete("{id}")]  // /api/tweeters/{id}
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var deletedTweet = _tweetRepo.DeleteTweet(id);
            if (deletedTweet == null)
            {
                return NotFound("Tweet not found.");
            }
            else
            {
                return Ok("Tweet deleted successfully");
            }
        }
    }
    public class TwitterBaseController : ControllerBase
    {
       
    }
}
