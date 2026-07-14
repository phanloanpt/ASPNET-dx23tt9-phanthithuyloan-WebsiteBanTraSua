using System;
using BLL;
using NewsModel = Model.News;


namespace TraSuaNgon
{
    public partial class NewsDetail : System.Web.UI.Page
    {

        NewsBLL newsBLL = new NewsBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNewsDetail();
            }
        }



        private void LoadNewsDetail()
        {

            int id = Convert.ToInt32(
                Request.QueryString["id"]);



            NewsModel news =
                newsBLL.GetNewsByID(id);



            if (news == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }



            lblTitle.Text =
                news.Title;


            lblAuthor.Text =
                news.Author;


            lblDate.Text =
                news.CreatedDate.ToString("dd/MM/yyyy");


            imgNews.ImageUrl =
                news.ImageURL;


            lblSummary.Text =
                news.Summary;


            litContent.Text =
                news.Content;

        }

    }
}