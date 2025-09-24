using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class HandleOrderPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Admin")
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                BindOrders();
            }
        }
        private void BindOrders()
        {
            var controller = new TransactionController();
            var orders = controller.GetUnfinishedOrders();
            gvOrders.DataSource = orders;
            gvOrders.DataBind();
        }

        public string GetActionField(object statusObj, object transactionIdObj)
        {
            string status = statusObj as string;
            string transactionId = transactionIdObj?.ToString() ?? "";

            if (status == "Payment Pending")
            {
                return $"<asp:Button runat='server' CommandName='ConfirmPayment' CommandArgument='{transactionId}' Text='Confirm Payment' />";
            }
            else if (status == "Shipment Pending")
            {
                return $"<asp:Button runat='server' CommandName='ShipPackage' CommandArgument='{transactionId}' Text='Ship Package' />";
            }
            else if (status == "Arrived")
            {
                return "Waiting for user confirmation…";
            }
            return string.Empty;
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var controller = new TransactionController();
            int transactionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ConfirmPayment")
            {
                controller.UpdateTransactionStatus(transactionId, "Shipment Pending");
            }
            else if (e.CommandName == "ShipPackage")
            {
                controller.UpdateTransactionStatus(transactionId, "Arrived");
            }
            BindOrders();
        }
    }
}