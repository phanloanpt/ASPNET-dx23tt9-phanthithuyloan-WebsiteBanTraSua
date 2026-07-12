using System;
using BLL;
using Model;


namespace TraSuaNgon
{

    public partial class Register : System.Web.UI.Page
    {


        UserBLL userBLL =
            new UserBLL();




        protected void Page_Load(
            object sender,
            EventArgs e)
        {

        }







        protected void btnRegister_Click(
            object sender,
            EventArgs e)
        {


            User user = new User();



            user.FullName =
                txtFullName.Text.Trim();



            user.Email =
                txtEmail.Text.Trim();



            user.PasswordHash =
                txtPassword.Text.Trim();



            user.Phone =
                txtPhone.Text.Trim();



            user.Address =
                txtAddress.Text.Trim();




            // KHÔNG CHO USER TỰ CHỌN ROLE

            user.Role = "Customer";



            user.Status = true;



            user.CreatedDate =
                DateTime.Now;






            bool result =
                userBLL.Register(user);





            if (result)
            {


                lblMessage.CssClass =
                    "text-success text-center d-block";



                lblMessage.Text =
                    "Đăng ký thành công! Vui lòng đăng nhập.";





                Response.AddHeader(
                    "REFRESH",
                    "2;URL=Login.aspx");



            }

            else
            {


                lblMessage.Text =
                    "Email đã tồn tại hoặc đăng ký thất bại!";


            }



        }



    }

}