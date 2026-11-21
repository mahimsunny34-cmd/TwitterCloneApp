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
    public class MessagesController: ControllerBase
    {
        public IMessageService _messageService;
        public MessagesController(IMessageService msg)
        {
            _messageService = msg;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMessages([FromQuery] Guid senderId, [FromQuery] Guid receiverId)
        {
            var messages=_messageService.GetMessages(senderId, receiverId);
            if (messages == null)
            {
                return NotFound("No messages found.");
            }
            return Ok(messages);
        }

        [HttpPost]
        public IActionResult CreateMessage([FromBody] CreateMessageDto msgDto )
        {
            var message = _messageService.CreateMessage(msgDto);
            if (message == null)
            {
                return BadRequest("Failed to create message.");
            }
            
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMessage(Guid id)
        {
            var updatedMessage = _messageService.UpdateMessage(id);
            if(updatedMessage == null)
            {
                return NotFound($"Message with ID {id} not found.");
            }
            return Ok(updatedMessage);
        }

        [HttpGet("conversation")]    //GET api/messages/conversation?senderId={senderId}&receiverId={receiverId}
        public IActionResult GetConversation([FromQuery] Guid senderId, [FromQuery] Guid receiverId)
        {
            var convo = _messageService.GetConversations(senderId, receiverId);
            if(convo == null)
            {
                return NotFound("No conversation found.");
            }
            return Ok(convo);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(Guid id)
        {
            return _messageService.GetMessageById(id) is ReadMessageDto message ? Ok(message) : NotFound($"Message with ID {id} not found.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(Guid id)
        {
            return _messageService.DeleteMessage(id) ?Ok("Message deleted successfully.") : NotFound($"Message with ID {id} not found.");
        }   
    }
}
