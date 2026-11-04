using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastratcure.Auth
{
    public class JwtTokenService:ITokenService
    {
        public (string,DateOnly) GetToken(ReadUserDto user)
        {
            //business logic to generate jwt token

            return (string.Empty, DateOnly.MinValue); 
        }
    }
}
