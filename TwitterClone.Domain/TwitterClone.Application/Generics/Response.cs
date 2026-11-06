using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;
using TwitterClone.Utilities;

namespace TwitterClone.Application.Generics
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
    }

    public class Test
    {
        public void Run()
        {
            var res = new Response<User>();
            res.IsSuccess = true;
            res.Data = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
            };
            var user = (User)res.Data;
            user.FirstName;

            var res1 = new Response<Tweet>();
            res1.IsSuccess = true;
            res1.Data = new Tweet("Hello, world!");
            
            var statusCode = res1.Data;
        }
    }
}
