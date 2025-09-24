using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class TransactionDetailPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Customer")
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadTransactionDetails();
            }
        }

        private void LoadTransactionDetails()
        {
            string transactionIdStr = Request.QueryString["transactionId"];
            int transactionId;
            if (!int.TryParse(transactionIdStr, out transactionId))
            {
                lblError.Text = "Invalid transaction ID.";
                return;
            }

            var controller = new TransactionController();
            var transaction = controller.GetUserTransactionById(transactionId);

            if (transaction == null || transaction.UserId != Convert.ToInt32(Session["UserId"]))
            {
                lblError.Text = "Transaction not found or access denied.";
                return;
            }

            lblTransactionId.Text = $"Transaction ID: {transaction.TransactionId}";

            var details = transaction.TransactionDetails
                .Select(d => new
                {
                    JewelName = d.MsJewel?.JewelName ?? "(Unknown)",
                    d.Quantity
                }).ToList();

            gvDetails.DataSource = details;
            gvDetails.DataBind();
        }
    }
}