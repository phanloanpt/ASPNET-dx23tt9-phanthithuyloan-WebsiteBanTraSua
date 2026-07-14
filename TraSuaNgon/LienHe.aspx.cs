using System;
using BLL;
using Model;

namespace TraSuaNgon
{
    public partial class LienHe : System.Web.UI.Page
    {
        private ContactBLL contactBLL = new ContactBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            ContactMessage contact = new ContactMessage();

            contact.FullName = txtName.Text.Trim();
            contact.Email = txtEmail.Text.Trim();
            contact.Phone = txtPhone.Text.Trim();

            // Form hiện tại không có ô Subject
            contact.Subject = "Liên hệ từ website";

            contact.Message = txtMessage.Text.Trim();
            contact.CreatedDate = DateTime.Now;
            contact.IsRead = false;

            bool result = contactBLL.InsertMessage(contact);

            if (result)
            {
                lblMessage.Text = "Gửi liên hệ thành công!";

                txtName.Text = "";
                txtEmail.Text = "";
                txtPhone.Text = "";
                txtMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Gửi liên hệ thất bại!";
            }
        }
    }
}