using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastratcure.Repositories
{
    public class MessageRepository:IMessageRepository
    {
        private readonly List<Message> _message = new List<Message>();

        public Message? AddMessage(Message msg)
        {
            _message.Add(msg);
            return msg;
        }

        public List<Message> ShowAllMessages(Guid senderId, Guid receiverId)
        {
            var messages = _message;
            if(senderId!=Guid.Empty)
            {
                messages=messages.Where(m=>m.SenderId == senderId).ToList();
            }
            if (receiverId != Guid.Empty)
            {
                messages = messages.Where(m => m.ReceiverId == receiverId).ToList() ;
            }
            return messages.ToList() ;
        }

        public Message? GetMessageById(Guid id)
        {
            var messageExists = _message.SingleOrDefault(m => m.Id == id);
            if (messageExists == null)
            {
                return null;
            }
            return messageExists;
        }

        public Message? UpdateMessage(Message updatedMsg)
        {
            _message.RemoveAll(m => m.Id == updatedMsg.Id);
            _message.Add(updatedMsg);
            return updatedMsg;
        }

        public List<Message> GetConversations(Guid senderId,Guid receiverId)
        {
            return _message.Where(m=>
                                 (m.SenderId==senderId && receiverId == m.ReceiverId) 
                                 ||
                                 (m.SenderId == receiverId || m.ReceiverId == senderId))
                                 .ToList();
        }

        public bool DeleteMessage(Guid id)
        {
            var removedMsg=_message.RemoveAll(m => m.Id == id);
            if(removedMsg>0)
            {
                return true;
            }
            return false;
        }
    }
}
