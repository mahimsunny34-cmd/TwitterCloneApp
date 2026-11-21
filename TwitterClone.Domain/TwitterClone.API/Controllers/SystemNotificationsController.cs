using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
namespace TwitterClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemNotificationsController : ControllerBase
    {
        public INotificationService _notificationService;
        public SystemNotificationsController(INotificationService ns)
        {
            _notificationService = ns;
        }
        [HttpGet]
        public IActionResult GetNotification([FromQuery] Guid? userId, [FromQuery] string? type, [FromQuery] bool? isRead)
        {
            return Ok(_notificationService.GetNotifications(userId,type,isRead));
        }

        [HttpPost]
        public IActionResult CreateNotification([FromBody] CreateNotificationDto notification)
        {
            return Ok(_notificationService.CreateNotification(notification));
        }

        [HttpGet("{id}")]
        public IActionResult GetNotificationById(Guid id)
        {
            return Ok(_notificationService.GetNotificationById(id));
        }

        [HttpPatch("{id}")]
        public IActionResult MarkAsRead(Guid id)
        {
            return Ok(_notificationService.MarkAsRead(id));
        }

        public IActionResult MarkAllNotificationAsRead(Guid userId)
        {
            return Ok(_notificationService.MarkAllNotificationsAsRead(userId));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(Guid id)
        {
            return Ok(_notificationService.DeleteNotification(id));
        }
    }
}
