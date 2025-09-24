using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
	public partial class DetailJewelPage : System.Web.UI.Page
	{
        JewelController jewelController = new JewelController();
        private int jewelId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["jewelId"] == null || !int.TryParse(Request.QueryString["jewelId"], out jewelId))
            {
                lblError.Text = "Invalid jewel ID.";
                pnlDetails.Visible = false;
                return;
            }

            if (!IsPostBack)
            {
                LoadJewelDetails(jewelId);
            }
        }
        private void LoadJewelDetails(int id)
        {
            var jewel = jewelController.GetJewelById(id);

            if (jewel == null)
            {
                lblError.Text = "Jewel not found.";
                pnlDetails.Visible = false;
                return;
            }

            lblName.Text = jewel.JewelName;
            lblCategory.Text = jewel.MsCategory?.CategoryName ?? "-";
            lblBrand.Text = jewel.MsBrand?.BrandName ?? "-";
            lblCountry.Text = jewel.MsBrand?.BrandCountry ?? "-";
            lblClass.Text = jewel.MsBrand?.BrandClass ?? "-";
            lblPrice.Text = $"${jewel.JewelPrice:N0}";
            lblYear.Text = jewel.JewelReleaseYear.ToString();

            pnlDetails.Visible = true;

            string userRole = Session["UserRole"] as string;
            btnAddToCart.Visible = (userRole == "Customer");
            btnUpdate.Visible = btnDelete.Visible = (userRole == "Admin");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                lblError.Text = "You must be logged in as a customer to add to cart.";
                return;
            }
            int userId = (int)Session["UserId"];
            bool success = jewelController.AddToCart(userId, jewelId);
            if (success)
                Response.Redirect("CartPage.aspx");
            else
                lblError.Text = "Failed to add to cart.";
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect($"UpdateJewel.aspx?jewelId={jewelId}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool success = jewelController.DeleteJewel(jewelId);
            if (success)
                Response.Redirect("HomePage.aspx");
            else
                lblError.Text = "Failed to delete jewel.";
        }
	}
}