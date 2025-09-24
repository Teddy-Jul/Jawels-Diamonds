using Project.Handler;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;

namespace Project.Controller
{
    public class UserController
    {
        UserHandler userHandler = new UserHandler();

        public Response<MsUser> ValidateLogin(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                return new Response<MsUser>(400, "Email is required.", null);

            if (string.IsNullOrWhiteSpace(password))
                return new Response<MsUser>(400, "Password is required.", null);

            MsUser user = userHandler.GetUser(email, password);
            if (user != null)
            {
                return new Response<MsUser>(200, "Login successful.", user);
            }
            return new Response<MsUser>(400, "Invalid email or password.", null);
        }

        public Response<MsUser> ValidateRegister(string email, string username, string password, string confirmpassword, string gender, DateTime dob)
        {
            if (string.IsNullOrWhiteSpace(email))
                return new Response<MsUser>(400, "Email is required.", null);

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return new Response<MsUser>(400, "Invalid email format.", null);

            if (string.IsNullOrWhiteSpace(username))
                return new Response<MsUser>(400, "Username is required.", null);

            if (username.Length < 3 || username.Length > 25)
                return new Response<MsUser>(400, "Username must be between 3 and 25 characters.", null);

            if (string.IsNullOrWhiteSpace(password))
                return new Response<MsUser>(400, "Password is required.", null);

            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"^[a-zA-Z0-9]{8,20}$"))
                return new Response<MsUser>(400, "Password must be alphanumeric and 8-20 characters.", null);

            if (string.IsNullOrWhiteSpace(confirmpassword))
                return new Response<MsUser>(400, "Confirm Password is required.", null);

            if (!password.Equals(confirmpassword))
                return new Response<MsUser>(400, "Password and Confirm Password do not match.", null);

            if (gender != "Male" && gender != "Female")
                return new Response<MsUser>(400, "Gender must be selected as Male or Female.", null);

            if (dob == DateTime.MinValue)
                return new Response<MsUser>(400, "Date of Birth is required.", null);

            if (dob >= new DateTime(2010, 1, 1))
                return new Response<MsUser>(400, "Date of Birth must be earlier than 01/01/2010.", null);


            MsUser user = userHandler.GetUserByEmail(email);
            if (user == null)
            {
                userHandler.HandleUserRegister(email, username, password, gender, dob);
                return new Response<MsUser>(200, "User Succesfully Register.", user);
            }
            return new Response<MsUser>(400, "Email already exists.", null);

        }
        public MsUser FindUserById(int userId)
        {
            return userHandler.GetUserById(userId);
        }

        public string UpdatePassword(int userId, string oldPassword, string newPassword, string confirmPassword)
        {
            var user = userHandler.GetUserById(userId);
            if (user == null)
                return "User not found.";

            if (oldPassword != user.UserPassword)
                return "Old password is incorrect.";

            if (newPassword.Length < 8 || newPassword.Length > 25 || !Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]+$"))
                return "New password must be 8-25 characters and alphanumeric.";

            if (newPassword != confirmPassword)
                return "Confirm password does not match new password.";

            bool result = userHandler.UpdatePassword(userId, newPassword);
            return result ? "Success" : "Failed to change password. Please try again.";
        }
    }
}