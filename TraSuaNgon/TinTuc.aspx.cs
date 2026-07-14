using System;
using BLL;


namespace TraSuaNgon
{
    public partial class TinTuc : System.Web.UI.Page
    {


        NewsBLL newsBLL =
            new NewsBLL();



        protected void Page_Load(
            object sender,
            EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadNews();
            }

        }



        private void LoadNews()
        {

            rptNews.DataSource =
                newsBLL.GetAllNews();


            rptNews.DataBind();

        }


    }
}