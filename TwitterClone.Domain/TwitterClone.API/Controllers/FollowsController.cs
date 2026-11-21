using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowsController : ControllerBase
    {
        
        public readonly IFollowService _followService;
        public FollowsController(IFollowService followService)
        {
            _followService = followService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetFollows([FromQuery] Guid followerId, [FromQuery] Guid followingId)
        {
            return Ok(_followService.ShowAllFollows(followerId, followingId));
        }
        [HttpGet("following/{userId}")]
        public IActionResult GetFollowing([FromQuery] Guid userId)
        {
            return Ok(_followService.ShowAllFollowing(userId));
        }
        [HttpGet("followers/{userId}")]
        public IActionResult GetFollowers([FromQuery] Guid userId)
        {
            return Ok(_followService.ShowFollowers(userId));
        }

        [HttpPost]
        public IActionResult CreateFollow([FromBody] FollowDto followDto)
        {
            var follow=_followService.AddFollow(followDto);
            return Ok(follow);
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteFollow([FromRoute] Guid id)
        {
            var result = _followService.DeleteFollow(id);
            return Ok(result);
        }
    }
}
