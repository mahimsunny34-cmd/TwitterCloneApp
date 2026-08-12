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
    }
}
