using Project.Factory;
using Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handler
{
    public class UserHandler
    {
        UserFactory userFactory = new UserFactory();
        UserRepository userRepository = new UserRepository();
        public UserHandler() { }

        public void HandleUserRegister(string email, string username, string password, string gender, DateTime dateOfBirth)
        {
            MsUser newuser = userFactory.CreateUser(email, username, password, gender, dateOfBirth);
            userRepository.AddUser(newuser);

        }

        public MsUser GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email);
        }

        public MsUser GetUser(string email, string password)
        {
            return userRepository.GetUser(email, password);
        }
        public MsUser GetUserById(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public bool UpdatePassword(int userId, string newPassword)
        {
            return userRepository.UpdatePassword(userId, newPassword);
        }
    }
}