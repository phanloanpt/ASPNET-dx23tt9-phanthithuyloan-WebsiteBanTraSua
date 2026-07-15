using System;
using BLL;
using Model;

namespace TraSuaNgon.Admin.Reports
{
    public partial class ReportDashboard :
        System.Web.UI.Page
    {
        private ReportBLL reportBLL =
            new ReportBLL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
                LoadBestSeller();
                LoadLowStock();
            }
        }

        private void LoadReport()
        {
            ReportModel report =
                reportBLL.GetDashboard();

            if (report == null)
            {
                lblTotalOrders.Text = "0";
                lblRevenue.Text = "0 đ";
                lblCompleted.Text = "0";
                lblCancelled.Text = "0";
                lblPending.Text = "0";
                lblProcessing.Text = "0";
                lblShipping.Text = "0";
                return;
            }

            lblTotalOrders.Text =
                report.TotalOrders.ToString();

            lblRevenue.Text =
                report.TotalRevenue.ToString("N0")
                + " đ";

            lblCompleted.Text =
                report.CompletedOrders.ToString();

            lblCancelled.Text =
                report.CancelledOrders.ToString();

            lblPending.Text =
                report.PendingOrders.ToString();

            lblProcessing.Text =
                report.ProcessingOrders.ToString();

            lblShipping.Text =
                report.ShippingOrders.ToString();
        }

        private void LoadBestSeller()
        {
            gvBestSeller.DataSource =
                reportBLL.GetBestSeller();

            gvBestSeller.DataBind();
        }

        private void LoadLowStock()
        {
            gvLowStock.DataSource =
                reportBLL.GetLowStock();

            gvLowStock.DataBind();
        }
    }
}