using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class MentionNotification:Notification
    {
        public Guid MentionByUserId {  get; set; }

        public MentionNotification(Guid MentionByUserId) : base("mention")
        {
            this.MentionByUserId = MentionByUserId;
        }

        public override string GetMessage()
        {
            return $"This ID : {MentionByUserId} has mention you in a tweet";
        }
    }
}
