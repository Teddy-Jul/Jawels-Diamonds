using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class UpdateJewel : System.Web.UI.Page
    {
        private int jewelId;
        JewelController jewelController = new JewelController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["jewelId"] == null || !int.TryParse(Request.QueryString["jewelId"], out jewelId))
                {
                    lblError.Text = "Invalid jewel ID.";
                    return;
                }
                BindDropdowns();
                LoadJewel(jewelId);
            }
        }

        private void BindDropdowns()
        {
            ddlCategory.DataSource = jewelController.GetAllCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();

            ddlBrand.DataSource = jewelController.GetAllBrands();
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataValueField = "BrandId";
            ddlBrand.DataBind();
        }

        private void LoadJewel(int id)
        {
            var jewel = jewelController.GetJewelById(id);
            if (jewel == null)
            {
                lblError.Text = "Jewel not found.";
                return;
            }
            txtName.Text = jewel.JewelName;
            ddlCategory.SelectedValue = jewel.CategoryId.ToString();
            ddlBrand.SelectedValue = jewel.BrandId.ToString();
            txtPrice.Text = jewel.JewelPrice.ToString();
            txtYear.Text = jewel.JewelReleaseYear.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["jewelId"] == null || !int.TryParse(Request.QueryString["jewelId"], out jewelId))
            {
                lblError.Text = "Invalid jewel ID.";
                return;
            }

            string name = txtName.Text.Trim();
            int categoryId, brandId, price, year;
            if (!int.TryParse(ddlCategory.SelectedValue, out categoryId) ||
                !int.TryParse(ddlBrand.SelectedValue, out brandId) ||
                !int.TryParse(txtPrice.Text.Trim(), out price) ||
                !int.TryParse(txtYear.Text.Trim(), out year))
            {
                lblError.Text = "Invalid input.";
                return;
            }

            string result = jewelController.UpdateJewel(jewelId, name, brandId, categoryId, price, year);
            if (result == "Jewel updated successfully.")
                Response.Redirect($"DetailJewelPage.aspx?jewelId={jewelId}");
            else
                lblError.Text = result;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect($"HomePage.aspx");
        }
    }
}