using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LikesController:ControllerBase
    {
        public ILikeService _likeService;
        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetLIkes([FromQuery] Guid? userId, [FromQuery] Guid? tweetId)
        {
            return Ok(_likeService.GetAllLikes(userId, tweetId));
        }

        [HttpPost]
        public IActionResult CreateLike([FromBody] CreateLikeDto createLikeDto)
        {
            var createLike = _likeService.AddLike(createLikeDto);
            if (createLike == null)
            {
                return BadRequest("nothing exists");
            }
            return Ok(createLike);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveLike([FromRoute] Guid id)
        {
            var deleteLike = _likeService.DeleteLike(id);
            if (!deleteLike)
            {
                return BadRequest("Could not delete");
            }
            return Ok("Deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetLikeById([FromRoute] Guid id)
        {
            var like = _likeService.LikeById(id);
            if (like == null)
            {
                return BadRequest("No like found");
            }
            return Ok(like);
        }
    }
}
