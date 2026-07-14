using System;

namespace TraSuaNgon
{
    public partial class LienHe : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(
            object sender,
            EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string message = txtMessage.Text.Trim();


            if (name == "" || email == "" || message == "")
            {
                lblMessage.Text =
                    "Vui lòng nhập đầy đủ thông tin.";

                lblMessage.CssClass =
                    "d-block text-danger fw-bold mt-2";

                return;
            }


            lblMessage.Text =
    "Cảm ơn bạn! Trà Sữa NGON sẽ phản hồi sớm nhất.";

            lblMessage.CssClass =
    "alert alert-success text-center mt-3";


            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtMessage.Text = "";
        }

    }
}