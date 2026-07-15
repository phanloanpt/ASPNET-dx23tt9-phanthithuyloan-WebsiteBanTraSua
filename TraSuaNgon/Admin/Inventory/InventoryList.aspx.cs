using BLL;
using Model;
using System;
using System.Web.UI.WebControls;


namespace TraSuaNgon.Admin.Inventory
{

    public partial class InventoryList :
        System.Web.UI.Page
    {


        private BLL.InventoryBLL inventoryBLL =
            new BLL.InventoryBLL();



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

            gvInventory.DataSource =
                inventoryBLL.GetAll();


            gvInventory.DataBind();

        }





        protected void gvInventory_RowDataBound(
            object sender,
            GridViewRowEventArgs e)
        {


            if (e.Row.RowType ==
                DataControlRowType.DataRow)
            {


                Model.Inventory item =
                    (Model.Inventory)e.Row.DataItem;



                Label lbl =
                    (Label)e.Row.FindControl(
                        "lblStatus");



                if (item.Quantity <=
                    item.MinimumQuantity)
                {

                    lbl.Text =
                        "⚠ Cần nhập thêm";

                    lbl.CssClass =
                        "badge bg-danger";

                }
                else
                {

                    lbl.Text =
                        "Đủ hàng";

                    lbl.CssClass =
                        "badge bg-success";

                }


            }


        }


    }

}