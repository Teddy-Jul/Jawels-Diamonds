using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class AddJewelPage : System.Web.UI.Page
    {
        JewelController jewelController = new JewelController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Admin")
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                BindCategories();
                BindBrands();
            }
        }

        private void BindCategories()
        {
            ddlCategory.DataSource = jewelController.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", ""));
        }

        private void BindBrands()
        {
            ddlBrand.DataSource = jewelController.GetAllBrands();
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataValueField = "BrandId";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-- Select Brand --", ""));
        }

        protected void btnAddJewel_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            string name = txtJewelName.Text.Trim();
            int categoryId, brandId, price, releaseYear;
            int.TryParse(ddlCategory.SelectedValue, out categoryId);
            int.TryParse(ddlBrand.SelectedValue, out brandId);
            int.TryParse(txtPrice.Text.Trim(), out price);
            int.TryParse(txtReleaseYear.Text.Trim(), out releaseYear);

            string result = jewelController.AddJewel(name, brandId, categoryId, price, releaseYear);
            if (result == "Jewel added successfully.")
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                lblError.Text = result;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
    }
}