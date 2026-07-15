using System;
using BLL;
using Model;


namespace TraSuaNgon.Admin.Inventory
{
    public partial class InventoryImport :
        System.Web.UI.Page
    {


        InventoryBLL inventoryBLL =
            new InventoryBLL();


        InventoryLogBLL logBLL =
            new InventoryLogBLL();



        protected void Page_Load(
            object sender,
            EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadInventory();
            }

        }




        private void LoadInventory()
        {

            ddlInventory.DataSource =
                inventoryBLL.GetAll();


            ddlInventory.DataTextField =
                "ItemName";


            ddlInventory.DataValueField =
                "InventoryID";


            ddlInventory.DataBind();

        }





        protected void btnImport_Click(
            object sender,
            EventArgs e)
        {


            int inventoryID =
                Convert.ToInt32(
                    ddlInventory.SelectedValue);



            int quantity;


            if (!int.TryParse(
                txtQuantity.Text,
                out quantity))
            {

                lblMessage.Text =
                    "Số lượng không hợp lệ";

                lblMessage.CssClass =
                    "text-danger";

                return;

            }



            if (quantity <= 0)
            {

                lblMessage.Text =
                    "Số lượng phải lớn hơn 0";

                lblMessage.CssClass =
                    "text-danger";

                return;

            }





            // tăng kho

            inventoryBLL.Import(
                inventoryID,
                quantity);





            // ghi lịch sử

            InventoryLog log =
                new InventoryLog();



            log.InventoryID =
                inventoryID;


            log.QuantityChanged =
                quantity;


            log.ActionType =
                "Nhập";


            log.Note =
                string.IsNullOrEmpty(
                    txtNote.Text)
                    ?
                    "Nhập kho"
                    :
                    txtNote.Text;



            logBLL.Insert(log);




            lblMessage.Text =
                "Nhập kho thành công";


            lblMessage.CssClass =
                "text-success";



            txtQuantity.Text = "";
            txtNote.Text = "";


        }

        protected void btnBack_Click(
    object sender,
    EventArgs e)
        {
            Response.Redirect("InventoryImport.aspx");
        }
    }
}