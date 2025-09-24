using Project.Controller;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        UserController UserController = new UserController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    Response.Redirect("HomePage.aspx");
                }
                else if (Request.Cookies["Remember_Token"] != null)
                {
                    int userId;
                    if (int.TryParse(Request.Cookies["Remember_Token"].Value, out userId))
                    {
                        var user = UserController.FindUserById(userId);
                        if (user != null)
                        {
                            Session["UserId"] = user.UserId;
                            Session["UserName"] = user.UserName;
                            Session["UserRole"] = user.UserRole;
                            Session["UserEmail"] = user.UserEmail;
                            Session["UserGender"] = user.UserGender;
                            Session["UserDOB"] = user.UserDOB;
                            Session["UserPassword"] = user.UserPassword;

                            Response.Redirect("HomePage.aspx");
                        }
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response<MsUser> response = UserController.ValidateLogin(txtEmail.Text, txtPassword.Text);
            if (response.statusCode == 200)
            {
                Session["UserId"] = response.data.UserId;
                Session["UserName"] = response.data.UserName;
                Session["UserRole"] = response.data.UserRole;

                if (cbRememberMe.Checked)
                {
                    HttpCookie userCookie = new HttpCookie("Remember_Token", response.data.UserId.ToString());
                    userCookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(userCookie);
                }

                Validation.ForeColor = Color.Green;
                Validation.Text = response.message;
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Validation.ForeColor = Color.Red;
                Validation.Text = response.message;
            }
        }
    }
}