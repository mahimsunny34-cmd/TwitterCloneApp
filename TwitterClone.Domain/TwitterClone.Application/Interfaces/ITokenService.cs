using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface ITokenService
    {
        (string, DateOnly) GetToken(ReadUserDto user);
    }
}
