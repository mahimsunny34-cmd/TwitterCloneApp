using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Tweet
    {
        public Guid Id { get; }
        public Guid AuthorId {  get; }
        public string Content { get; set; }
        public Tweet(string content, Guid authorId)
        {
            Id = Guid.NewGuid();
            Content = content;
            AuthorId = authorId;
        }
    }
}
