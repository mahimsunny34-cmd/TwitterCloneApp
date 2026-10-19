using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public ReadUserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
                string.IsNullOrWhiteSpace(createUserDto.Email) ||
                string.IsNullOrWhiteSpace(createUserDto.LastName))
            {
                return null;
            }

            var emailExists = _userRepo.GetUserByEmail(createUserDto.Email);
            if (emailExists != null)
            {
                return null;
            }

            var user = new User //User object is created by the CreateUserDto object datas and stored in the user variable.
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                Email = createUserDto.Email
            };

            var createdUser = _userRepo.AddUser(user); //The user object is added to the UserRepository and stored in the createdUser variable.
            return new ReadUserDto
            {
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            };
        }

        public bool DeleteUser(Guid id)
        {
            if(Guid.Empty == id)
            {
                return false;
            }
            var userExists = _userRepo.GetUserById(id);
            return userExists != null && _userRepo.DeleteUser(userExists);
        }

        public ReadUserDto? GetUserById(Guid id)
        {
            if (Guid.Empty == id)
            {
                return null;
            }
            var user = _userRepo.GetUserById(id);
            if (user == null)
            {
                return null;
            }
            return new ReadUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public ReadUserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            if (Guid.Empty == id || string.IsNullOrWhiteSpace(updateUserDto.FirstName) || string.IsNullOrWhiteSpace(updateUserDto.LastName))
            {
                return null;
            }

            var userExists = _userRepo.GetUserById(id);
            if (userExists == null)
            {
                return null;
            }

            userExists.FirstName = updateUserDto.FirstName;
            userExists.LastName = updateUserDto.LastName;

            var updatedUser = _userRepo.UpdateUser(userExists);
            if (updatedUser == null)
            {
                return null;
            }


            return new ReadUserDto
            {
                FirstName = userExists.FirstName,
                LastName = userExists.LastName,
                Email = userExists.Email
            };
        }

        List<ReadUserDto> GetAllUsers()
        {
            var users = _userRepo.ShowUsers();
            return users.Select(u => new ReadUserDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();
        }

        List<ReadUserDto> IUserService.GetAllUsers()
        {
            return GetAllUsers();
        }
    }
}
