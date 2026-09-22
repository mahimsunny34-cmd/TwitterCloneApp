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
        public IActionResult GetFollows()
        {
            var follows = new List<Follow>
            {
                new Follow(Guid.NewGuid(), Guid.NewGuid()),
            };
            return Ok(follows);
        }
        [HttpPost]
        public IActionResult CreateFollow()
        {
            var newFollow = new Follow (Guid.NewGuid(), Guid.NewGuid());
            return Ok(newFollow);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFollow([FromRoute] Guid id)
        {
            var updatedFollow = new Follow(id, Guid.NewGuid());
            return Ok(updatedFollow);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFollow(Guid id)
        {
            return Ok($"Follow with ID {id} deleted.");
        }]
    }
}
