using System;
using BLL;
using NewsModel = Model.News;

namespace TraSuaNgon.Admin.News
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        NewsBLL newsBLL = new NewsBLL();

        int NewsID
        {
            get
            {
                if (Request.QueryString["id"] == null)
                    return 0;

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
                LoadNews();
            }
        }

        private void LoadNews()
        {
            NewsModel news =
                newsBLL.GetNewsByID(
                    NewsID);

            if (news == null)
                return;

            txtTitle.Text =
                news.Title;

            txtSummary.Text =
                news.Summary;

            txtContent.Text =
                news.Content;

            txtImage.Text =
                news.ImageURL;

            imgPreview.ImageUrl =
                news.ImageURL;

            txtAuthor.Text =
                news.Author;

            chkFeatured.Checked =
                news.IsFeatured;

            chkStatus.Checked =
                news.Status;
        }

        protected void btnSave_Click(
            object sender,
            EventArgs e)
        {
            NewsModel news =
                new NewsModel();

            news.NewsID =
                NewsID;

            news.Title =
                txtTitle.Text;

            news.Summary =
                txtSummary.Text;

            news.Content =
                txtContent.Text;

            news.Author =
                txtAuthor.Text;

            news.IsFeatured =
                chkFeatured.Checked;

            news.Status =
                chkStatus.Checked;

            if (fuImage.HasFile)
            {
                string fileName =
                    System.IO.Path.GetFileName(
                        fuImage.FileName);

                string folder =
                    Server.MapPath(
                        "~/Assets/images/news/");

                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(
                        folder);
                }

                fuImage.SaveAs(
                    folder + fileName);

                news.ImageURL =
                    "/Assets/images/news/" +
                    fileName;
            }
            else
            {
                news.ImageURL =
                    txtImage.Text;
            }

            newsBLL.UpdateNews(news);

            Response.Redirect(
                "NewsList.aspx");
        }
    }
}