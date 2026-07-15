using BLL;
using Model;
using System;


namespace TraSuaNgon.Admin.Contact

{
    public partial class ContactDetail : System.Web.UI.Page
    {


        private ContactBLL contactBLL =
            new ContactBLL();



        private int MessageID
        {
            get
            {
                return Convert.ToInt32(
                    Request.QueryString["id"]);
            }
        }




        protected void Page_Load(
            object sender,
            EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadDetail();
            }

        }







        private void LoadDetail()
        {


            ContactMessage contact =
                contactBLL.GetMessageByID(MessageID);



            if (contact == null)
            {
                Response.Redirect(
                    "ContactList.aspx");

                return;
            }




            lblName.Text =
                contact.FullName;



            lblEmail.Text =
                contact.Email;



            lblPhone.Text =
                contact.Phone;



            lblSubject.Text =
                contact.Subject;



            lblMessage.Text =
                contact.Message;



            lblDate.Text =
                contact.CreatedDate
                .ToString("dd/MM/yyyy HH:mm");



            if (contact.IsRead)
            {
                btnRead.Visible = false;
            }



        }







        protected void btnRead_Click(
            object sender,
            EventArgs e)
        {

            contactBLL.MarkAsRead(
                MessageID);



            Response.Redirect(
                Request.RawUrl);

        }


    }
}