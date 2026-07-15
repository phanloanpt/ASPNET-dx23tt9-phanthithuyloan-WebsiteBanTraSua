using System;
using System.Collections.Generic;
using BLL;
using Model;


namespace TraSuaNgon.Admin.Orders
{
    public partial class PrintInvoice : System.Web.UI.Page
    {

        private OrderBLL orderBLL = new OrderBLL();


        protected int OrderID
        {
            get
            {
                int id;

                if (int.TryParse(
                    Request.QueryString["id"],
                    out id))
                {
                    return id;
                }

                return 0;
            }
        }



        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadInvoice();
            }
        }



        // ===============================
        // LOAD HÓA ĐƠN
        // ===============================
        private void LoadInvoice()
        {

            if (OrderID == 0)
            {
                return;
            }



            Model.Order order =
                orderBLL.GetOrderByID(OrderID);



            if (order == null)
            {
                return;
            }



            // Thông tin đơn hàng

            lblOrderID.Text =
                order.OrderID.ToString();



            lblDate.Text =
                order.OrderDate.ToString(
                    "dd/MM/yyyy HH:mm");



            lblCustomer.Text =
                order.CustomerName;



            lblPhone.Text =
                order.Phone;



            lblTotal.Text =
                order.TotalAmount.ToString("N0")
                + " đ";




            // Danh sách sản phẩm

            List<Model.OrderDetail> details =
                orderBLL.GetOrderDetails(OrderID);



            rptDetail.DataSource =
                details;


            rptDetail.DataBind();

        }

    }
}