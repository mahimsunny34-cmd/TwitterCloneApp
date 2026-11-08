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

        public List<Message> ShowAllMessages()
        {
            return _message;
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
