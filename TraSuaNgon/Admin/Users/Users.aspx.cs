using System;
using System.Web.UI.WebControls;
using BLL;


namespace TraSuaNgon.Admin.Users
{

    public partial class Users : System.Web.UI.Page
    {


        private UserBLL userBLL =
            new UserBLL();





        protected void Page_Load(
            object sender,
            EventArgs e)
        {


            // kiểm tra đăng nhập Admin

            if (Session["UserID"] == null ||
                Session["Role"] == null ||
                Session["Role"].ToString() != "Admin")
            {

                Response.Redirect(
                    "~/Login.aspx");

                return;

            }





            if (!IsPostBack)
            {

                LoadUsers();

            }


        }








        // ===============================
        // LOAD DANH SÁCH USER
        // ===============================

        private void LoadUsers()
        {


            gvUsers.DataSource =
                userBLL.GetAllUsers();



            gvUsers.DataBind();


        }









        // ===============================
        // KHÓA / MỞ KHÓA USER
        // ===============================

        protected void gvUsers_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {


            if (e.CommandName == "ChangeStatus")
            {


                string data =
                    e.CommandArgument
                    .ToString();



                string[] values =
                    data.Split('|');




                int userID =
                    Convert.ToInt32(
                        values[0]);




                bool currentStatus =
                    Convert.ToBoolean(
                        values[1]);





                // đổi trạng thái

                userBLL.UpdateStatus(
                    userID,
                    !currentStatus);





                // load lại danh sách

                LoadUsers();


            }


        }



    }

}