using System;
using BLL;
using Model;
using System.Collections.Generic;

namespace TraSuaNgon
{
    public partial class OrderSuccess : System.Web.UI.Page
    {
        private OrderBLL orderBLL =
            new OrderBLL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                int orderID;

                if (!int.TryParse(
                    Request.QueryString["id"],
                    out orderID))
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                LoadOrder(orderID);
            }
        }

        private void LoadOrder(
    int orderID)
        {
            Order order =
                orderBLL.GetOrderByID(orderID);

            if (order == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            lblOrderID.Text =
                order.OrderID.ToString();

            lblCustomerName.Text =
                order.CustomerName;

            lblPhone.Text =
                order.Phone;

            lblOrderDate.Text =
                order.OrderDate.ToString(
                    "dd/MM/yyyy HH:mm");

            lblTotal.Text =
                order.TotalAmount.ToString("N0");

            List<OrderDetail> details =
                orderBLL.GetOrderDetails(orderID);

            gvOrderDetails.DataSource =
                details;

            gvOrderDetails.DataBind();
        }
    }
}