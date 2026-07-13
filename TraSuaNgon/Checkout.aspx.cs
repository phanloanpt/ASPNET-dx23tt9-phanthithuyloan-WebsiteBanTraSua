using System;
using System.Collections.Generic;
using BLL;
using Model;


namespace TraSuaNgon
{
    public partial class Checkout : System.Web.UI.Page
    {

        private OrderBLL orderBLL =
            new OrderBLL();



        protected void Page_Load(
            object sender,
            EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCheckout();
                LoadUserInfo();
            }

        }





        // ================================
        // LOAD GIỎ HÀNG
        // ================================

        private void LoadCheckout()
        {

            if (Session["Cart"] == null)
            {
                Response.Redirect("Menu.aspx");
                return;
            }



            List<CartItem> cart =
                (List<CartItem>)Session["Cart"];



            if (cart.Count == 0)
            {
                Response.Redirect("Menu.aspx");
                return;
            }



            gvCheckout.DataSource = cart;

            gvCheckout.DataBind();



            decimal total = 0;


            foreach (CartItem item in cart)
            {
                total += item.TotalPrice;
            }



            lblTotal.Text =
                total.ToString("N0");

        }







        // ================================
        // TỰ ĐIỀN THÔNG TIN USER
        // ================================

        private void LoadUserInfo()
        {

            if (Session["UserID"] == null)
            {
                return;
            }



            txtName.Text =
                Session["FullName"]?.ToString();



            txtPhone.Text =
                Session["Phone"]?.ToString();



            txtAddress.Text =
                Session["Address"]?.ToString();

        }









        // ================================
        // ĐẶT HÀNG
        // ================================

        protected void btnOrder_Click(
            object sender,
            EventArgs e)
        {


            if (Session["UserID"] == null)
            {

                Session["ReturnUrl"] =
                    "Checkout.aspx";


                Response.Redirect(
                    "Login.aspx");


                return;

            }






            List<CartItem> cart =
                (List<CartItem>)Session["Cart"];




            if (cart == null || cart.Count == 0)
            {
                Response.Redirect("Menu.aspx");
                return;
            }







            // =============================
            // TẠO ORDER
            // =============================


            Order order =
                new Order();



            order.UserID =
                Convert.ToInt32(
                    Session["UserID"]);



            order.CustomerName =
                txtName.Text.Trim();



            order.ReceiverName =
                txtName.Text.Trim();



            order.Phone =
                txtPhone.Text.Trim();



            order.ShippingAddress =
                txtAddress.Text.Trim();



            order.Note =
                txtNote.Text.Trim();



            order.OrderDate =
                DateTime.Now;



            order.Status =
                "Chờ xác nhận";



            decimal total = 0;



            foreach (CartItem item in cart)
            {
                total += item.TotalPrice;
            }



            order.TotalAmount =
                total;






            int orderID =
                orderBLL.CreateOrder(order);





            if (orderID > 0)
            {



                // =============================
                // LƯU CHI TIẾT ĐƠN
                // =============================


                foreach (CartItem item in cart)
                {


                    OrderDetail detail =
                        new OrderDetail();



                    detail.OrderID =
                        orderID;



                    detail.ProductID =
                        item.ProductID;



                    detail.Quantity =
                        item.Quantity;



                    detail.Size =
                        item.Size;



                    detail.UnitPrice =
                        item.UnitPrice;



                    detail.SubTotal =
                        item.TotalPrice;





                    int orderDetailID =
                        orderBLL.AddOrderDetail(detail);

                    Response.Write(
    "ProductID: " + detail.ProductID +
    "<br/>OrderID: " + detail.OrderID +
    "<br/>OrderDetailID: " + orderDetailID
);

                    Response.End();







                    // =============================
                    // LƯU TOPPING
                    // =============================


                    if (item.ToppingIDs != null)
                    {


                        foreach (int toppingID in item.ToppingIDs)
                        {


                            OrderDetailTopping topping =
                                new OrderDetailTopping();



                            topping.OrderDetailID =
                                orderDetailID;



                            topping.ToppingID =
                                toppingID;



                            topping.Quantity =
                                1;



                            topping.Price =
                                0;



                            orderBLL.AddOrderDetailTopping(
                                topping);

                        }

                    }



                }





                // XÓA GIỎ HÀNG

                Session["Cart"] = null;




                Response.Redirect(
                    "OrderSuccess.aspx?id="
                    + orderID);

            }


        }


    }
}