using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Application.Services
{
    public class AuthService:IAuthService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;

        public AuthService(IPasswordHasher passwordHasher,IUserRepository userRepo,ITokenService tokenService)
        {
            _passwordHasher = passwordHasher;
            _userRepo = userRepo;
            _tokenService = tokenService;
        }
        public AuthResponseDto? Login(LoginDto loginDto)
        {
            var userExists=_userRepo.GetUserByEmail(loginDto.Email);
            var userReadDto = new ReadUserDto
            {
                FirstName = userExists.FirstName,
                LastName = userExists.LastName,
                Email = userExists.Email
            };
            var verify= _passwordHasher.VerifyPassword(loginDto.Password, userExists.HashedPassword);
            
            if (verify)
            {
                var (token, expiryTime) = _tokenService.GetToken(userReadDto);
                return new AuthResponseDto
                {
                    AccessToken = token,
                    ExpiryTime = expiryTime,
                    User = userReadDto
                };
            }
            return null;
        }
    }
}
