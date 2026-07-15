using System;
using BLL;
using Model;


namespace TraSuaNgon.Admin.Orders
{
    public partial class OrderDetail : System.Web.UI.Page
    {

        private OrderBLL orderBLL =
            new OrderBLL();


        private InventoryBLL inventoryBLL =
            new InventoryBLL();



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





        protected void Page_Load(
            object sender,
            EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadOrder();
            }

        }






        private void LoadOrder()
        {

            if (OrderID == 0)
            {
                Response.Redirect(
                    "OrderList.aspx");

                return;
            }




            Order order =
                orderBLL.GetOrderByID(
                    OrderID);




            if (order == null)
            {
                Response.Redirect(
                    "OrderList.aspx");

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



            lblTotal.Text =
                order.TotalAmount.ToString("N0")
                + " đ";




            if (ddlStatus.Items.FindByValue(order.Status) != null)
            {
                ddlStatus.SelectedValue =
                    order.Status;
            }





            var detailList =
                orderBLL.GetOrderDetails(
                    OrderID);




            gvDetail.DataSource =
                detailList;



            gvDetail.DataBind();

        }









        // ===============================
        // CẬP NHẬT TRẠNG THÁI + TRỪ KHO
        // ===============================

        protected void btnUpdate_Click(
            object sender,
            EventArgs e)
        {

            Order oldOrder =
                orderBLL.GetOrderByID(
                    OrderID);



            string oldStatus =
                oldOrder.Status;



            string newStatus =
                ddlStatus.SelectedValue;




            orderBLL.UpdateStatus(
                OrderID,
                newStatus);





            // chỉ trừ kho khi chuyển sang Hoàn thành lần đầu

            if (oldStatus != "Hoàn thành"
                &&
                newStatus == "Hoàn thành")
            {

                ExportInventory();

            }




            LoadOrder();

        }









        // ===============================
        // XỬ LÝ TRỪ KHO
        // ===============================

        private void ExportInventory()
        {

            var details =
                orderBLL.GetOrderDetails(
                    OrderID);




            foreach (var item in details)
            {


                if (item.Size == "M")
                {

                    ExportItem(
                        "Ly size M",
                        item.Quantity);



                    ExportItem(
                        "Nắp size M",
                        item.Quantity);

                }

                else
                {

                    ExportItem(
                        "Ly size L",
                        item.Quantity);



                    ExportItem(
                        "Nắp size L",
                        item.Quantity);

                }





                ExportItem(
                    "Ống hút",
                    item.Quantity);

            }

        }









        private void ExportItem(
            string itemName,
            int quantity)
        {

            Model.Inventory item =
                inventoryBLL.GetByName(
                    itemName);




            if (item == null)
                return;





            inventoryBLL.Export(
                item.InventoryID,
                quantity);

        }









        // ===============================
        // QUAY LẠI DANH SÁCH ĐƠN HÀNG
        // ===============================

        protected void btnBack_Click(
            object sender,
            EventArgs e)
        {

            Response.Redirect(
                "OrderList.aspx");

        }


    }
}