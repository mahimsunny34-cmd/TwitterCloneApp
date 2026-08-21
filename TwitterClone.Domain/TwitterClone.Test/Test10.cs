using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Test
{
    public class Test10
    {
        public void Run()
        {
            Tweet tweet1 = new ("This is my new content", Guid.NewGuid());
            Console.WriteLine(tweet1.DescribeRecord());
            tweet1.AddContent("wassup");

            tweet1.CanBeLiked();
        }
}
}
