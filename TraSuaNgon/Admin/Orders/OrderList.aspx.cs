using System;
using BLL;


namespace TraSuaNgon.Admin.Orders
{

    public partial class OrderList : System.Web.UI.Page
    {


        OrderBLL orderBLL =
            new OrderBLL();



        protected void Page_Load(
            object sender,
            EventArgs e)
        {


            if (!IsPostBack)
            {
                LoadOrders();
            }


        }






        private void LoadOrders()
        {

            gvOrders.DataSource =
                orderBLL.GetAllOrders();


            gvOrders.DataBind();

        }








        protected void gvOrders_RowCommand(
            object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Detail")
            {


                int orderID =
                    Convert.ToInt32(
                        e.CommandArgument);



                Response.Redirect(
                    "OrderDetail.aspx?id="
                    + orderID);


            }


        }



    }

}