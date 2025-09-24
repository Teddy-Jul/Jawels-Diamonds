using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
	public partial class CartPage : System.Web.UI.Page
	{
        CartController cartController = new CartController();
        protected global::System.Web.UI.WebControls.GridView gvCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Customer")
            {
                Response.Redirect("HomePage.aspx");
                return;
            }
            if (!IsPostBack)
            {
                BindCart();
            }
        }

        private void BindCart()
        {
            lblError.Text = "";
            int userId = (int)Session["UserId"];
            var cartItems = cartController.GetCartItems(userId)
                .Select(c => new
                {
                    c.JewelId,
                    c.MsJewel.MsBrand.BrandName,
                    Price = c.MsJewel.JewelPrice,
                    Quantity = c.Quantity,
                    Subtotal = c.MsJewel.JewelPrice * c.Quantity
                }).ToList();

            gvCart.DataSource = cartItems;
            gvCart.DataBind();

            lblTotal.Text = "Total: $" + cartItems.Sum(i => i.Subtotal).ToString("N0");
        }

        protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = (int)Session["UserId"];
            int rowIndex = ((GridViewRow)((Control)e.CommandSource).NamingContainer).RowIndex;
            int jewelId = Convert.ToInt32(gvCart.DataKeys[rowIndex].Value);

            if (e.CommandName == "UpdateItem")
            {
                TextBox txtQty = (TextBox)gvCart.Rows[rowIndex].FindControl("txtQuantity");
                int newQty;
                if (!int.TryParse(txtQty.Text, out newQty) || newQty <= 0)
                {
                    lblError.Text = "Quantity must be a number greater than 0.";
                    return;
                }
                string result = cartController.UpdateCartItem(userId, jewelId, newQty);
                if (result != "Success") lblError.Text = result;
                BindCart();
            }
            else if (e.CommandName == "RemoveItem")
            {
                cartController.RemoveCartItem(userId, jewelId);
                BindCart();
            }
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserId"];
            cartController.ClearCart(userId);
            BindCart();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (string.IsNullOrEmpty(ddlPayment.SelectedValue))
            {
                lblError.Text = "Please select a payment method.";
                return;
            }
            int userId = (int)Session["UserId"];
            string paymentMethod = ddlPayment.SelectedValue;
            var transactionController = new TransactionController();
            string result = transactionController.Checkout(userId, paymentMethod);
            if (result == "Success")
                Response.Redirect("HomePage.aspx");
            else
                lblError.Text = result;
        }
    }
}