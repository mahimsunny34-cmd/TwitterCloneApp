using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastratcure.Auth
{
    public class PasswordHasher:IPasswordHasher
    {
        public bool VerifyPassword(string password, string hashedPassword)
        {
            //business logic to verify password
            return true;
        }
    }
}
