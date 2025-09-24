using Project.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class MyOrderPage : System.Web.UI.Page
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
                BindOrders();
            }
        }

        private void BindOrders()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            var controller = new TransactionController();
            var orders = controller.GetUserTransactions(userId)
                .Select(o => new
                {
                    o.TransactionId,
                    o.TransactionDate,
                    o.PaymentMethod,
                    o.TransactionStatus
                }).ToList();

            gvOrders.DataSource = orders;
            gvOrders.DataBind();
        }
        public string GetActionButtons(object statusObj, object transactionIdObj)
        {
            string status = statusObj as string;
            string transactionId = transactionIdObj?.ToString() ?? "";
            if (status == "Arrived")
            {
                return $@"
                        <asp:Button runat='server' CommandName='ConfirmPackage' CommandArgument='{transactionId}' Text='Confirm Package' />
                        <asp:Button runat='server' CommandName='RejectPackage' CommandArgument='{transactionId}' Text='Reject Package' />";
            }
            return "";
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var controller = new TransactionController();
            int transactionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ViewDetails")
            {
                Response.Redirect($"TransactionDetailPage.aspx?transactionId={transactionId}");
            }
            else if (e.CommandName == "ConfirmPackage")
            {
                controller.UpdateTransactionStatus(transactionId, "Done");
                BindOrders();
            }
            else if (e.CommandName == "RejectPackage")
            {
                controller.UpdateTransactionStatus(transactionId, "Rejected");
                if (e.CommandName == "ViewDetails")
                {
                    Response.Redirect($"TransactionDetailPage.aspx?transactionId={transactionId}");
                }
                BindOrders();
            }
        }
        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus") as string;
                var btnConfirm = (Button)e.Row.FindControl("btnConfirm");
                var btnReject = (Button)e.Row.FindControl("btnReject");

                if (status == "Arrived")
                {
                    btnConfirm.Visible = true;
                    btnReject.Visible = true;
                }
            }
        }
    }
}