using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class ProfilePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var controller = new UserController();
            var user = controller.FindUserById(userId);

            if (user != null)
            {
                lblUsername.Text = user.UserName;
                lblEmail.Text = user.UserEmail;
                lblGender.Text = user.UserGender;
                lblDOB.Text = user.UserDOB.ToString("yyyy-MM-dd");
            }
            else
            {
                lblError.Text = "User not found.";
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            lblStatus.ForeColor = System.Drawing.Color.Red;

            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            int userId = Convert.ToInt32(Session["UserId"]);
            var controller = new UserController();
            string result = controller.UpdatePassword(userId, oldPassword, newPassword, confirmPassword);

            if (result == "Success")
            {
                Session["UserPassword"] = newPassword;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Password changed successfully.";
                txtOldPassword.Text = txtNewPassword.Text = txtConfirmPassword.Text = "";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = result;
            }
        }
    }
}