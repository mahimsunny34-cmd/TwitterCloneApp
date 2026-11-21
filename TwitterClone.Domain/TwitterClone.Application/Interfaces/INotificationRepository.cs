using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface INotificationRepository
    {
        public Notification? AddNotification(Notification notification);
        List<Notification> GetNotifications(Guid? userId, string? type, bool? isRead);
        Notification? GetNotificationById(Guid id);
        Notification? MarkAsRead(Guid id);
        List<Notification> MarkAllNotificationsAsRead(Guid userId);
        bool DeleteNotification(Guid id);

    }
}
