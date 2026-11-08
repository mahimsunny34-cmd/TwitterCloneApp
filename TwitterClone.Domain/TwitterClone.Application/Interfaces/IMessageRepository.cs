using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IMessageRepository
    {
        Message? AddMessage(Message msg);
        List<Message> ShowAllMessages();
        Message? GetMessageById(Guid id);
        Message? UpdateMessage(Message updatedMsg);
        bool DeleteMessage(Guid id);
    }
}
