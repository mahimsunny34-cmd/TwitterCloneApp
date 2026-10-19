using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookmarksController:ControllerBase
    {
        public readonly IBookmarkService _bookmarkService;
        public BookmarksController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBookmarks()
        {
            var bookmarks = _bookmarkService.GetBookmarks();
            return Ok(bookmarks);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateBookmark([FromBody] CreateBookmarkDto dto)
        {
            var createdBookmark=_bookmarkService.CreateBookmark(dto);
            return Ok(createdBookmark);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookmark([FromRoute] Guid id, [FromBody] UpdateBookmarkDto dto)
        {
            var updatedBookmark=_bookmarkService.UpdateBookmark(id, dto);
            return Ok(updatedBookmark);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookmark([FromRoute] Guid id)
        {
            var deleted=_bookmarkService.DeleteBookmark(id);
            if (!deleted)
            {
                return NotFound($"Bookmark with ID {id} not found.");
            }
            return Ok($"Bookmark with ID {id} deleted.");
        }
    }
}
