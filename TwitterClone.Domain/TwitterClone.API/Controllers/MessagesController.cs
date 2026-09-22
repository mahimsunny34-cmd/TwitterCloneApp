using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessagesController: ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMessages()
        {
            var messages = new List<Message>
                {
                    new Message(Guid.NewGuid(), Guid.NewGuid(), "Hello, this is a message."),
                    new Message(Guid.NewGuid(), Guid.NewGuid(), "This is another message.")
                };
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult CreateMessage()
        {
            var newMessage = new Message(Guid.NewGuid(), Guid.NewGuid(), "This is a new message.");
            return Ok(newMessage);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMessage(Guid id)
        {
            var updatedMessage = new Message(id, Guid.NewGuid(), "This is an updated message.");
            return Ok(updatedMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(Guid id)
        {
            return Ok($"Message with ID {id} deleted.");
        }   
    }
}
