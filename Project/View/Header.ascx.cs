using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class Header : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuildNavBar();
        }

        private void BuildNavBar()
        {
            phNavLinks.Controls.Clear();

            string userName = Session["UserName"] as string;
            string userRole = Session["UserRole"] as string;

            lblWelcome.Text = !string.IsNullOrEmpty(userName) ? $"Welcome, {userName} | " : "";

            phNavLinks.Controls.Add(CreateNavLink("Home", "HomePage.aspx"));

            if (userRole == "Admin")
            {
                phNavLinks.Controls.Add(CreateNavLink("Add Jewel", "AddJewelPage.aspx"));
                phNavLinks.Controls.Add(CreateNavLink("Reports", "TransactionReports.aspx"));
                phNavLinks.Controls.Add(CreateNavLink("Handle Orders", "HandleOrderPage.aspx"));
                phNavLinks.Controls.Add(CreateNavLink("Profile", "ProfilePage.aspx"));
                phNavLinks.Controls.Add(CreateNavLink("Logout", "LogOut.aspx"));
            }
            else if (userRole == "Customer")
            {
                phNavLinks.Controls.Add(CreateNavLink("Cart", "CartPage.aspx"));
                phNavLinks.Controls.Add(CreateNavLink("My Orders", "MyOrderPage.aspx"));
                phNavLinks.Controls.Add(CreateNavLink("Profile", "ProfilePage.aspx"));
                phNavLinks.Controls.Add(CreateNavLink("Logout", "LogOut.aspx"));
            }
            else
            {
                phNavLinks.Controls.Add(CreateNavLink("Login", "LoginPage.aspx"));
                phNavLinks.Controls.Add(CreateNavLink("Register", "RegisterPage.aspx"));
            }
        }

        private Control CreateNavLink(string text, string url)
        {
            HyperLink link = new HyperLink();
            link.Text = text + " | ";
            link.NavigateUrl = url;
            return link;
        }
    }
}