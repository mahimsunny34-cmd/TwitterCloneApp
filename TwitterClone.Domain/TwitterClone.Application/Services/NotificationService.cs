using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class NotificationService : INotificationService
    {
        public readonly IUserRepository _userRepository;
        public readonly INotificationRepository _notificationRepository;
        public NotificationService(IUserRepository userRepository, INotificationRepository notificationRepository)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
        }
        public ReadNotificationDto? CreateNotification(CreateNotificationDto createNotificationDto)
        {
            if(string.IsNullOrWhiteSpace(createNotificationDto.NotificationType) ||  createNotificationDto.UserId==Guid.Empty||createNotificationDto.TriggeredByUserId==Guid.Empty)
            {
                return null;
            }

            var userExists=_userRepository.GetUserById(createNotificationDto.UserId);
            if(userExists == null)
            {
                return null;
            }
            var triggeredUserExists = _userRepository.GetUserById(createNotificationDto.TriggeredByUserId.Value);
            if(triggeredUserExists == null)
            {
                return null;
            }

            var notification = BuildNotificatiton(createNotificationDto.NotificationType);
            if(notification == null)
            {
                return null;
            }

            var addNotification =_notificationRepository.AddNotification(notification);
            return new ReadNotificationDto
            {
                NotificationType = addNotification.NotificationType,
                UserId = addNotification.UserId,
            };
        }

        public bool DeleteNotification(Guid id)
        {
            var notificationExists = _notificationRepository.GetNotificationById(id);
            if (notificationExists == null)
            {
                return false;
            }

            _notificationRepository.DeleteNotification(id);
            return true;
        }

        public ReadNotificationDto? GetNotificationById(Guid id)
        {
            var notificationExists = _notificationRepository.GetNotificationById(id);
            if(notificationExists == null)
            {
                return null;
            }
            return new ReadNotificationDto
            {
                NotificationType = notificationExists.NotificationType,
                UserId = notificationExists.UserId,
                IsRead = notificationExists.IsRead,
            };
        }

        public List<ReadNotificationDto> GetNotifications(Guid? userId, string? type, bool? isRead)
        {
            var notifications = _notificationRepository.GetNotifications(userId, type, isRead);
            var readNotificationDtos = notifications.Select(n => new ReadNotificationDto
            {
                UserId = n.UserId,
                NotificationType = n.NotificationType,
                IsRead = n.IsRead,
            }).ToList();
            
            return readNotificationDtos.ToList();
        }

        public List<ReadNotificationDto> MarkAllNotificationsAsRead(Guid userId)
        {
            var userNotifications = _notificationRepository.MarkAllNotificationsAsRead(userId);
            foreach (var notification in userNotifications)
            {
                notification.IsRead = true;
            }
            return userNotifications.Select(n=> new ReadNotificationDto
            {
                UserId = n.UserId,
                NotificationType = n.NotificationType,
                IsRead = n.IsRead,
            }).ToList();
        }

        public ReadNotificationDto? MarkAsRead(Guid notificationId)
        {
            var notificationExists=_notificationRepository.GetNotificationById(notificationId);
            if(notificationExists == null)
            {
                return null;
            }
            notificationExists.IsRead = true;
            return new ReadNotificationDto
            {
                UserId = notificationExists.UserId,
                NotificationType = notificationExists.NotificationType,
                IsRead = notificationExists.IsRead,
            };
        }

        private static Notification BuildNotificatiton(string type)
        {
            return type switch
            {
                "Like" => new LikeNotification(Guid.NewGuid()),
                "Comment" => new CommentNotification(Guid.NewGuid()),
                "Mention" => new MentionNotification(Guid.NewGuid()),
                "FriendRequest" => new FriendRequestNotification(Guid.NewGuid()),
                "System" => new SystemNotification("you have an update"),
                _ => throw new ArgumentException($"Invalid notification type: {type}"),
            };
        }
    }
}
