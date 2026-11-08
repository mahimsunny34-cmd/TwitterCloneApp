using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowsController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetFollows([FromQuery] string user)
        {
            return Ok();
        }
        [HttpGet("following/{userId}")]
        public IActionResult GetFollowing([FromQuery] Guid userId)
        {
            return Ok();
        }
        [HttpGet("followers/{userId}")]
        public IActionResult GetFollowers([FromQuery] Guid userId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateFollow([FromBody] Follow follow)
        {
            return Ok();
        }

        [HttpDelete("{userId}")]
        public IActionResult UnfollowUser([FromRoute] Guid userId)
        {
            return Ok();
        }
    }
}
