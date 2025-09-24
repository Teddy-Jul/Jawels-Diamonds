using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
	public partial class LogOut : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            if (Request.Cookies["Remember_Token"] != null)
            {
                Response.Cookies["Remember_Token"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("LoginPage.aspx");
        }
    }
}