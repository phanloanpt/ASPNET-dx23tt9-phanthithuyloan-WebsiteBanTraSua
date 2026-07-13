using System;
using BLL;
using NewsModel = Model.News;

namespace TraSuaNgon.Admin.News
{
    public partial class NewsList : System.Web.UI.Page
    {
        NewsBLL newsBLL = new NewsBLL();

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
            gvNews.DataSource =
                newsBLL.GetAllNews();

            gvNews.DataBind();
        }

        protected void gvNews_RowCommand(
            object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id =
                Convert.ToInt32(
                    e.CommandArgument);

            if (e.CommandName == "EditNews")
            {
                Response.Redirect(
                    "NewsEdit.aspx?id=" + id);
            }

            if (e.CommandName == "DeleteNews")
            {
                newsBLL.DeleteNews(id);

                LoadNews();
            }
        }
    }
}