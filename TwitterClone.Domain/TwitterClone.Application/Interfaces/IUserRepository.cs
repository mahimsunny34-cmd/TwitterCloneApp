using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User? UpdateUser(User user);
        User? GetUserById(Guid id);
        bool DeleteUser(User user);
        List<User> ShowUsers();
        User? GetUserByEmail(string email);
    }
}
