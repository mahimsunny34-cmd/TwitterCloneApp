using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserService
    {
        List<ReadUserDto> GetAllUsers();
        ReadUserDto? CreateUser(CreateUserDto createUserDto);
        ReadUserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto);
        ReadUserDto? GetUserById(Guid id);
        bool DeleteUser(Guid id);
    }
}
