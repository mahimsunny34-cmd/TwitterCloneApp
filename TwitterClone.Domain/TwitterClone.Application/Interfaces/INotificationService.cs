using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface INotificationService
    {
        ReadNotificationDto? CreateNotification(CreateNotificationDto createNotificationDto);
        ReadNotificationDto? GetNotificationById(Guid id);
        List<ReadNotificationDto> GetNotifications(Guid? userId, string? type, bool? isRead);
        ReadNotificationDto? MarkAsRead(Guid id);
        List<ReadNotificationDto> MarkAllNotificationsAsRead(Guid userId);
        bool DeleteNotification(Guid id);
    }
}
