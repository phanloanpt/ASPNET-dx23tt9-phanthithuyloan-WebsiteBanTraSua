using BLL;
using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TraSuaNgon.Admin.Orders
{

    public partial class OrderList : System.Web.UI.Page
    {


        OrderBLL orderBLL = new OrderBLL();



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







        // ==================================
        // UPDATE STATUS + DETAIL
        // ==================================

        protected void gvOrders_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {


            if (e.CommandName == "UpdateStatus")
            {


                int orderID =
                    Convert.ToInt32(
                        e.CommandArgument);



                GridViewRow row =
                    (GridViewRow)
                    ((Button)e.CommandSource)
                    .NamingContainer;



                DropDownList ddlStatus =
                    (DropDownList)
                    row.FindControl("ddlStatus");



                string status =
                    ddlStatus.SelectedValue;



                orderBLL.UpdateStatus(
                    orderID,
                    status);



                LoadOrders();

            }






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









        // ==================================
        // LOAD TRẠNG THÁI HIỆN TẠI
        // ==================================

        protected void gvOrders_RowDataBound(
            object sender,
            GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList ddlStatus =
                    (DropDownList)
                    e.Row.FindControl("ddlStatus");



                if (ddlStatus != null)
                {


                    string status =
                        DataBinder.Eval(
                            e.Row.DataItem,
                            "Status")
                        .ToString();



                    if (ddlStatus.Items.FindByValue(status) != null)
                    {

                        ddlStatus.SelectedValue =
                            status;


                    }


                    // tô màu dropdown

                    SetStatusColor(
                        ddlStatus,
                        status);

                }


            }


        }








        // ==================================
        // ĐỔI MÀU TRẠNG THÁI
        // ==================================

        private void SetStatusColor(
            DropDownList ddl,
            string status)
        {


            switch (status)
            {


                case "Chờ xác nhận":

                    ddl.BackColor =
                        Color.LightYellow;

                    ddl.ForeColor =
                        Color.DarkOrange;

                    break;



                case "Đang pha chế":

                    ddl.BackColor =
                        Color.LightBlue;

                    ddl.ForeColor =
                        Color.DarkBlue;

                    break;




                case "Đang giao":

                    ddl.BackColor =
                        Color.LightCyan;

                    ddl.ForeColor =
                        Color.DarkCyan;

                    break;




                case "Hoàn thành":

                    ddl.BackColor =
                        Color.LightGreen;

                    ddl.ForeColor =
                        Color.DarkGreen;

                    break;




                case "Đã hủy":

                    ddl.BackColor =
                        Color.MistyRose;

                    ddl.ForeColor =
                        Color.DarkRed;

                    break;



                default:

                    ddl.BackColor =
                        Color.White;

                    ddl.ForeColor =
                        Color.Black;

                    break;


            }


        }



    }

}