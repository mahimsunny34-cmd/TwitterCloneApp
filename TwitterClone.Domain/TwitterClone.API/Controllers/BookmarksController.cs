using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarksController:ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBookmarks()
        {
            var bookMarks = new List<Bookmark>
            {
                new Bookmark(Guid.NewGuid(), Guid.NewGuid())
            };
            return Ok(bookMarks);
        }

        [HttpPost]
        public IActionResult CreateBookmark()
        {
            var newBookmark = new Bookmark(Guid.NewGuid(), Guid.NewGuid());
            return Ok(newBookmark);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookmark(Guid id)
        {
            var updatedBookmark = new Bookmark(id, Guid.NewGuid());
            return Ok(updatedBookmark);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark(Guid id)
        {
            return Ok($"Bookmark with ID {id} deleted.");
        }
    }
}
