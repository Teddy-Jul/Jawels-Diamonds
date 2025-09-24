using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using Project.Controller;
using Project.Datasets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.View
{
    public partial class TransactionReports : System.Web.UI.Page
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
                LoadReport();
            }
        }

        private void LoadReport()
        {
            var controller = new DatasetController();
            List<TransactionHeader> transactions = controller.GetSuccessfulTransactions();

            DataSet1 dataset = GetDataSet(transactions);
            ReportDocument report = new ReportDocument();
            string reportPath = Server.MapPath("~/Reports/CrystalReport1.rpt");
            report.Load(reportPath);
            report.SetDataSource(dataset);

            CrystalReportViewer1.ReportSource = report;
            CrystalReportViewer1.DataBind();
        }

        private DataSet1 GetDataSet(List<TransactionHeader> transactions)
        {
            DataSet1 dataset = new DataSet1();
            var userIds = new HashSet<int>();
            var jewelIds = new HashSet<int>();

            foreach (var header in transactions)
            {
                if (header.MsUser != null && userIds.Add(header.UserId))
                {
                    var userRow = dataset.MsUser.NewMsUserRow();
                    userRow.UserId = header.MsUser.UserId.ToString();
                    userRow.UserName = header.MsUser.UserName;
                    dataset.MsUser.AddMsUserRow(userRow);
                }

                var headerRow = dataset.TransactionHeader.NewTransactionHeaderRow();
                headerRow.TransactionId = header.TransactionId.ToString();
                headerRow.UserId = header.UserId.ToString();
                headerRow.TransactionDate = header.TransactionDate.ToString("yyyy-MM-dd");
                headerRow.PaymentMethod = header.PaymentMethod;
                headerRow.TransactionStatus = header.TransactionStatus;
                dataset.TransactionHeader.AddTransactionHeaderRow(headerRow);

                foreach (var detail in header.TransactionDetails)
                {
                    if (detail.MsJewel != null && jewelIds.Add(detail.JewelId))
                    {
                        var jewelRow = dataset.MsJewel.NewMsJewelRow();
                        jewelRow.JewelId = detail.MsJewel.JewelId.ToString();
                        jewelRow.JewelName = detail.MsJewel.JewelName;
                        jewelRow.JewelPrice = detail.MsJewel.JewelPrice.ToString();
                        jewelRow.BrandId = detail.MsJewel.BrandId.ToString();
                        jewelRow.CategoryId = detail.MsJewel.CategoryId.ToString();
                        dataset.MsJewel.AddMsJewelRow(jewelRow);
                    }

                    var detailRow = dataset.TransactionDetail.NewTransactionDetailRow();
                    detailRow.TransactionId = header.TransactionId.ToString();
                    detailRow.JewelId = detail.JewelId.ToString();
                    detailRow.JewelName = detail.MsJewel?.JewelName ?? "";
                    detailRow.Quantity = detail.Quantity.ToString();
                    detailRow.JewelPrice = detail.MsJewel?.JewelPrice.ToString() ?? "0";
                    detailRow.SubTotal = (detail.Quantity * (detail.MsJewel?.JewelPrice ?? 0)).ToString();
                    dataset.TransactionDetail.AddTransactionDetailRow(detailRow);
                }
            }

            return dataset;
        }
    }
}