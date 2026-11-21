using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos
{
    public class ReadNotificationDto
    {
        public Guid UserId { get; set; }
        public string NotificationType { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
