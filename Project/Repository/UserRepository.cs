using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repository
{
	public class UserRepository
	{
		Database1Entities1 db = new Database1Entities1();

        public void AddUser(MsUser user)
		{
			db.MsUsers.Add(user);
			db.SaveChanges();
        }

		public MsUser GetUser(string email, string password)
        {
            return db.MsUsers.Where(u => u.UserEmail.Equals(email) && u.UserPassword.Equals(password)).FirstOrDefault();
        }

        public MsUser GetUserByEmail(string email)
		{
            return db.MsUsers.Where(u => u.UserEmail.Equals(email)).FirstOrDefault();
        }

        public MsUser GetUserById(int userId)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserId == userId);
        }
        public bool UpdatePassword(int userId, string newPassword)
        {
            var user = db.MsUsers.FirstOrDefault(u => u.UserId == userId);
            if (user == null) return false;

            user.UserPassword = newPassword;
            db.SaveChanges();
            return true;
        }

    }
}