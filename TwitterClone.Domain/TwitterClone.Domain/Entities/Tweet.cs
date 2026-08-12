using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Tweet:EntityBase
    {
        public Guid AuthorId { get; set; }
        public string Content { get; set; }
        public Tweet(string content, Guid authorId):base(Guid.NewGuid())
        {
            this.Content = content;
            this.AuthorId = authorId;
        }
    }
}
