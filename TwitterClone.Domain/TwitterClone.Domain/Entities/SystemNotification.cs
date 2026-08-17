using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class SystemNotification:Notification
    {
        public string SystemMessage { get; set;}
        public SystemNotification(string systemMessage):base("System Message")
        {
            this.SystemMessage = systemMessage;
        }  
        
        public void AddMessage(string message)
        {
            this.Message = message;
        }

        public override string GetMessage()
        {
            return $"There is a software update";
        }
    }
}
