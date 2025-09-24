using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindJewels();
            }
        }
        

        private void BindJewels()
        {
            using (var db = new Database1Entities1())
            {
                var jewels = db.MsJewels
                    .Select(j => new { j.JewelId, j.JewelName, j.JewelPrice })
                    .ToList();
                gvJewels.DataSource = jewels;
                gvJewels.DataBind();
            }
        }

        protected void gvJewels_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                string jewelId = e.CommandArgument.ToString();
                Response.Redirect($"DetailJewelPage.aspx?jewelId={jewelId}");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }
    }
}