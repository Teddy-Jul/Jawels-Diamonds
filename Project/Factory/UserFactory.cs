using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Factory
{
    public class UserFactory
    {
        public UserFactory() { }
        public MsUser CreateUser(string email, string username, string password, string gender, DateTime dateOfBirth)
        {
            return new MsUser
            {
                UserEmail = email,
                UserName = username,
                UserPassword = password,
                UserGender = gender,
                UserDOB = dateOfBirth,
                UserRole = "Customer"
            };
        }
    }
}