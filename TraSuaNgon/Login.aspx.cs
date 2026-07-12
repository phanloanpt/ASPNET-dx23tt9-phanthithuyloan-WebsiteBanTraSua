using System;
using BLL;
using Model;


namespace TraSuaNgon
{
    public partial class Login : System.Web.UI.Page
    {


        UserBLL userBLL = new UserBLL();




        protected void Page_Load(
            object sender,
            EventArgs e)
        {

        }








        protected void btnLogin_Click(
            object sender,
            EventArgs e)
        {


            string email =
                txtEmail.Text.Trim();



            string password =
                txtPassword.Text.Trim();





            User user =
                userBLL.Login(
                    email,
                    password);







            if (user != null)
            {



                if (user.Status == false)
                {

                    lblMessage.Text =
                    "Tài khoản đã bị khóa!";

                    return;

                }









                // LƯU THÔNG TIN USER


                Session["UserID"] =
                    user.UserID;



                Session["FullName"] =
                    user.FullName;



                Session["Email"] =
                    user.Email;



                Session["Phone"] =
                    user.Phone;



                Session["Address"] =
                    user.Address;



                Session["Role"] =
                    user.Role;









                // =========================
                // ADMIN
                // =========================

                if (user.Role == "Admin")
                {

                    Response.Redirect(
                        "~/Admin/Dashboard.aspx");


                    return;

                }









                // =========================
                // USER
                // =========================


                if (Session["ReturnUrl"] != null)
                {


                    string url =
                        Session["ReturnUrl"].ToString();



                    Session.Remove(
                        "ReturnUrl");



                    Response.Redirect(url);


                    return;

                }







                // Không có trang trước đó

                Response.Redirect(
                    "~/Default.aspx");


            }





            else
            {

                lblMessage.Text =
                "Email hoặc mật khẩu không đúng!";

            }



        }


    }

}