using System;


namespace TraSuaNgon.Admin
{

    public partial class Admin : System.Web.UI.MasterPage
    {


        protected void Page_Load(
            object sender,
            EventArgs e)
        {


            CheckAdminLogin();


        }







        // ================================
        // KIỂM TRA QUYỀN ADMIN
        // ================================

        private void CheckAdminLogin()
        {


            // Chưa đăng nhập

            if (Session["UserID"] == null)
            {

                Response.Redirect(
                    "~/Login.aspx");

                return;

            }






            // Không phải Admin

            if (Session["Role"] == null ||
                Session["Role"].ToString() != "Admin")
            {

                Response.Redirect(
                    "~/Default.aspx");

                return;

            }



        }





    }

}