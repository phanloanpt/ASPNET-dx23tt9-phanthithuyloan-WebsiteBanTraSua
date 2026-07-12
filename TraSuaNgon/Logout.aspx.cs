using System;


namespace TraSuaNgon
{

    public partial class Logout : System.Web.UI.Page
    {


        protected void Page_Load(
            object sender,
            EventArgs e)
        {


            // Xóa toàn bộ session đăng nhập

            Session.Clear();

            Session.Abandon();



            // Quay về trang chủ

            if (Session["ReturnUrl"] != null)
            {

                string url =
                    Session["ReturnUrl"].ToString();


                Session.Remove("ReturnUrl");


                Response.Redirect(url);

            }
            else
            {

                Response.Redirect(
                    "Default.aspx");

            }


        }


    }

}