using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Dtos;

namespace TwitterClone.Application.Dtos
{
    public class AuthResponseDto
    {
        public required string AccessToken { get; set; }
        public required DateOnly ExpiryAt { get; set; }
        public required ReadUserDto User { get; set; }
    }
}
