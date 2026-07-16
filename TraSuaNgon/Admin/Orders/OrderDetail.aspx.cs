using System;
using System.Collections.Generic;
using BLL;
using Model;
using InventoryModel = Model.Inventory;
using OrderDetailModel = Model.OrderDetail;

namespace TraSuaNgon.Admin.Orders
{
    public partial class OrderDetail :
        System.Web.UI.Page
    {
        private OrderBLL orderBLL =
            new OrderBLL();

        private InventoryBLL inventoryBLL =
            new InventoryBLL();

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
                LoadOrder();

                // link in hóa đơn
                lnkPrint.NavigateUrl =
                    "PrintInvoice.aspx?id="
                    + OrderID;
            }
        }

        // ===============================
        // LOAD ĐƠN HÀNG
        // ===============================
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

            lblOrderDate.Text =
                order.OrderDate.ToString(
                    "dd/MM/yyyy HH:mm");

            if (ddlStatus.Items.FindByValue(
                order.Status) != null)
            {
                ddlStatus.SelectedValue =
                    order.Status;
            }

            List<OrderDetailModel> detailList =
     orderBLL.GetOrderDetails(OrderID);

            gvDetail.DataSource =
                detailList;

            gvDetail.DataBind();
        }

        // ===============================
        // CẬP NHẬT TRẠNG THÁI
        // ===============================
        protected void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            Order oldOrder =
                orderBLL.GetOrderByID(
                    OrderID);

            if (oldOrder == null)
                return;

            string oldStatus =
                oldOrder.Status;

            string newStatus =
                ddlStatus.SelectedValue;

            bool result =
                orderBLL.UpdateStatus(
                    OrderID,
                    newStatus);

            if (result)
            {
                // Chỉ trừ kho 1 lần duy nhất
                if (oldStatus != "Hoàn thành"
                    &&
                    newStatus == "Hoàn thành")
                {
                    ExportInventory();
                }

                LoadOrder();
            }
        }

        // ===============================
        // TRỪ KHO
        // ===============================
        private void ExportInventory()
        {
            List<OrderDetailModel> details =
                orderBLL.GetOrderDetails(OrderID);

            foreach (OrderDetailModel item in details)
            {
                if (item.Size == "M")
                {
                    ExportItem("Ly size M", item.Quantity);
                    ExportItem("Nắp size M", item.Quantity);
                }
                else
                {
                    ExportItem("Ly size L", item.Quantity);
                    ExportItem("Nắp size L", item.Quantity);
                }

                ExportItem("Ống hút", item.Quantity);
            }
        }

        private void ExportItem(
            string itemName,
            int quantity)
        {
            InventoryModel item =
    inventoryBLL.GetByName(itemName);

            if (item == null)
                return;

            inventoryBLL.Export(
                item.InventoryID,
                quantity);
        }

        // ===============================
        // QUAY LẠI
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