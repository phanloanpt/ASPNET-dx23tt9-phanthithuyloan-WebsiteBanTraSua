using System;


namespace TraSuaNgon
{
    public partial class OrderSuccess : System.Web.UI.Page
    {


        protected void Page_Load(
            object sender,
            EventArgs e)
        {


            if (!IsPostBack)
            {


                if (Request.QueryString["id"] != null)
                {

                    lblOrderID.Text =
                        Request.QueryString["id"];

                }

                else
                {

                    lblOrderID.Text =
                        "N/A";

                }


            }


        }


    }
}