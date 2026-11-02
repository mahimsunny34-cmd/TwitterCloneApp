using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RetweetsController: ControllerBase
    {
        [HttpGet]
        public IActionResult GetRetweets()
        {
            return Ok("Get Retweets");
        }

        [HttpPost]
        public IActionResult CreateRetweet([FromBody] CreateRetweetDto createRetweetDto)
        {
            return Ok("Create Retweet");
        }

        [HttpGet("{id}")]
        public IActionResult GetRetweetById([FromRoute] Guid id)
        {
            return Ok($"Get Retweet by Id: {id}");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRetweet([FromRoute] Guid id, [FromBody] UpdateRetweetDto updateRetweetDto)
        {
            return Ok($"Update Retweet with Id: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRetweet([FromRoute] Guid id)
        {
            return Ok($"Delete Retweet with Id: {id}");
        }
    }
}
