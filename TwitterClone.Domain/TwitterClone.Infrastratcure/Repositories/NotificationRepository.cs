using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastratcure.Repositories
{
    public class NotificationRepository:INotificationRepository
    {
        private readonly List<Notification> _notifications = new List<Notification>();
        public Notification? AddNotification(Notification notification)
        {
            _notifications.Add(notification);
            return notification;
        }
        public List<Notification> GetNotifications(Guid? id, string? type, bool? isRead)
        {
            var notifications = _notifications;
            if (id != Guid.Empty)
            {
                return notifications.Where(n=>n.UserId == id).ToList();
            }

            if(!string.IsNullOrEmpty(type))
            {
                return notifications.Where(n => n.NotificationType == type).ToList();
            }

            if (isRead!=false)
            {
                return notifications.Where(n => n.IsRead == isRead).ToList();   
            }

            return notifications;
        }
        public Notification? GetNotificationById(Guid id)
        {
            var notificationExists = _notifications.FirstOrDefault(n => n.Id == id);
            if (notificationExists == null)
            {
                return null;
            }
            return notificationExists;
        }
        public Notification? MarkAsRead(Guid id) //its a specific notifiaction update notId is used
        {
            var notificationExists=_notifications.SingleOrDefault(n=>n.Id==id);
            if (notificationExists != null)
            {
                notificationExists.IsRead = true;
            }
            return notificationExists;
        }
        public List<Notification> MarkAllNotificationsAsRead(Guid userId)
        {
            var markUserNotificationsAsRead = _notifications.Where(n => n.UserId == userId);
            return markUserNotificationsAsRead.ToList();
        }
        public bool DeleteNotification(Guid id)
        {
            var notificationExists = _notifications.FirstOrDefault(n => n.Id == id);
            if (notificationExists != null)
            {
                _notifications.Remove(notificationExists);
                return true;
            }
            return false;
        }
    }
}
