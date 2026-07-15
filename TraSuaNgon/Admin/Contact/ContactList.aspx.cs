using BLL;
using System;
using System.Web.UI.WebControls;

namespace TraSuaNgon.Admin.Contact
{
    public partial class ContactList : System.Web.UI.Page
    {

        private ContactBLL contactBLL =
            new ContactBLL();



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadContacts();
            }

        }




        private void LoadContacts()
        {

            gvContacts.DataSource =
                contactBLL.GetAllMessages();


            gvContacts.DataBind();

        }




        protected void gvContacts_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Detail")
            {

                int id =
                    Convert.ToInt32(
                        e.CommandArgument);


                Response.Redirect(
                    "ContactDetail.aspx?id=" + id);

            }


        }


    }
}