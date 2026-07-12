using System;
using BLL;
using Model;

namespace TraSuaNgon.Admin.Orders
{
    public partial class OrderDetail : System.Web.UI.Page
    {

        private OrderBLL orderBLL = new OrderBLL();


        private int OrderID
        {
            get
            {
                if (Request.QueryString["id"] == null)
                    return 0;

                return Convert.ToInt32(
                    Request.QueryString["id"]);
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Role"] == null ||
                Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Login.aspx");
                return;
            }


            if (!IsPostBack)
            {
                LoadOrder();
            }

        }




        private void LoadOrder()
        {

            if (OrderID == 0)
            {
                Response.Redirect("OrderList.aspx");
                return;
            }



            Order order =
                orderBLL.GetOrderByID(OrderID);



            if (order == null)
            {
                Response.Redirect("OrderList.aspx");
                return;
            }



            lblOrderID.Text =
                order.OrderID.ToString();


            lblCustomer.Text =
                order.CustomerName;


            lblPhone.Text =
                order.Phone;


            lblAddress.Text =
                order.ShippingAddress;



            if (ddlStatus.Items.FindByValue(order.Status) != null)
            {
                ddlStatus.SelectedValue =
                    order.Status;
            }



            gvDetail.DataSource =
                orderBLL.GetOrderDetails(OrderID);


            gvDetail.DataBind();

        }





        protected void btnUpdate_Click(
            object sender,
            EventArgs e)
        {


            orderBLL.UpdateStatus(
                OrderID,
                ddlStatus.SelectedValue);



            Response.Redirect(
                "OrderDetail.aspx?id=" + OrderID);

        }


    }
}