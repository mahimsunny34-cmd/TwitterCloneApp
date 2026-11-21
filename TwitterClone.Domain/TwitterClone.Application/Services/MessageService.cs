using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class MessageService : IMessageService
    {
        IMessageRepository _message;
        public MessageService(IMessageRepository message)
        {
            _message = message;
        }
        public ReadMessageDto? CreateMessage(CreateMessageDto msgDto)
        {
            if(msgDto.SenderId == Guid.Empty || msgDto.ReceiverId == Guid.Empty || string.IsNullOrEmpty(msgDto.Content))
            {
                return null;
            }

            var newMessage=new Message(msgDto.SenderId, msgDto.ReceiverId, msgDto.Content);
            var addMsg = _message.AddMessage(newMessage);
            var readMessage = new ReadMessageDto
            {
                SenderId = addMsg.SenderId,
                Content = addMsg.Content,
                ReceiverId = addMsg.ReceiverId
            };
            return readMessage;
        }

        public bool DeleteMessage(Guid id)
        {
            var messageDeleted = _message.DeleteMessage(id);
            if (!messageDeleted) return false;
            return true;
        }

        public List<ReadMessageDto> GetConversations(Guid senderId, Guid receiverId)
        {
            if(senderId==Guid.Empty || receiverId == Guid.Empty)
            {
                return null;
            }
            var conversation = _message.GetConversations(senderId, receiverId);
            if(conversation == null ) return null;

            var readMessages = conversation.Select(m => new ReadMessageDto
            {
                SenderId=m.SenderId,
                Content = m.Content,
                ReceiverId = m.ReceiverId
            });
            return readMessages.ToList();
        }

        public ReadMessageDto? GetMessageById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }

            var message= _message.GetMessageById(id);
            if (message == null)
            {
                return null;
            }

            var readMessage = new ReadMessageDto
            {
                SenderId = message.SenderId,
                Content = message.Content,
                ReceiverId = message.ReceiverId
            };

            return readMessage;
        }

        public List<ReadMessageDto> GetMessages(Guid senderId, Guid receiverId)
        {
            if (senderId == Guid.Empty || receiverId == Guid.Empty)
            {
                return null;
            }

            var message = _message.ShowAllMessages(senderId, receiverId);
            var readMessages = message.Select(m => new ReadMessageDto
            {
                SenderId = m.SenderId,
                Content = m.Content,
                ReceiverId=m.ReceiverId
            });
            return readMessages.ToList();
        }

        public ReadMessageDto? UpdateMessage(Guid id)
        {
            if (id == Guid.Empty)
            {
                return null;
            }
                 
            var message = _message.GetMessageById(id);
            if (message == null)
            {
                return null;
            }

            var updatedMessage = _message.UpdateMessage(message);
            return new ReadMessageDto
            {
                SenderId = updatedMessage.SenderId,
                Content = updatedMessage.Content,
                ReceiverId = updatedMessage.ReceiverId
            };
        }
    }
}
