using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class Tweet:EntityBase,ILikeable
    {
        public Guid AuthorId { get; set; }
        public string Content { get; set; }
        public Tweet(string content, Guid authorId):base(Guid.NewGuid())
        {
            this.Content = content;
            this.AuthorId = authorId;
        }
        public Tweet (string content):base(Guid.NewGuid())
        {
            this.Content = content;
        }

        public void AddContent(string content)
        {
            this.Content = content;
        }

        public void AddContent(string content, Guid authorId)
        {
            this.Content = content;
            this.AuthorId= authorId;
        }
        public override string DescribeRecord()
        {
            return $"{base.DescribeRecord()}, Author is { AuthorId } , Content : {Content}";
        }

        //interface application 
        public bool CanBeLiked()
        {
            return true;
        }
    }
}
