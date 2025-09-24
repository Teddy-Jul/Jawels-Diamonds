using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Project.View
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e) 		
		{

		}
		
		protected void Session_Start(object sender, EventArgs e) 
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) 
		{

		}

		protected void Application_Error(object sender, EventArgs e) 
		{

		}

		protected void Session_End(object sender, EventArgs e) 
		{

		}

		protected void Application_End(object sender, EventArgs e) 
		{

		}
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;

            if (context.Session != null && context.Session["UserId"] == null && context.Request.Cookies["Remember_Token"] != null)
            {
                int userId;
                if (int.TryParse(context.Request.Cookies["Remember_Token"].Value, out userId))
                {
                    var userController = new Project.Controller.UserController();
                    var user = userController.FindUserById(userId);
                    if (user != null)
                    {
                        context.Session["UserId"] = user.UserId;
                        context.Session["UserRole"] = user.UserRole;
                        context.Session["UserName"] = user.UserName;
                        context.Session["UserEmail"] = user.UserEmail;
                        context.Session["UserGender"] = user.UserGender;
                        context.Session["UserDOB"] = user.UserDOB;
                        context.Session["UserPassword"] = user.UserPassword;
                    }
                    else
                    {
                        context.Response.Cookies["Remember_Token"].Expires = DateTime.Now.AddDays(-1);
                    }
                }
            }
        }
    }
}