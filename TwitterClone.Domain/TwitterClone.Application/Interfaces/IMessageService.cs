using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IMessageService
    {
        ReadMessageDto? CreateMessage(CreateMessageDto msgDto);
        List<ReadMessageDto> GetMessages(Guid senderId, Guid receiverId);
        ReadMessageDto? GetMessageById(Guid id);
        ReadMessageDto? UpdateMessage(Guid id);
        List<ReadMessageDto> GetConversations(Guid senderId, Guid receiverId);
        bool DeleteMessage(Guid id);
    }
}
