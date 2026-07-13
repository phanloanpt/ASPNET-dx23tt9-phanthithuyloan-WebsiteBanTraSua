using System;
using BLL;
using NewsModel = Model.News;

namespace TraSuaNgon.Admin.News
{
    public partial class NewsAdd : System.Web.UI.Page
    {
        NewsBLL newsBLL =
            new NewsBLL();

        protected void btnSave_Click(
            object sender,
            EventArgs e)
        {
            NewsModel news =
                new NewsModel();

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

            news.CreatedDate =
                DateTime.Now;



            // Upload ảnh
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
                news.ImageURL = "";
            }



            newsBLL.InsertNews(news);

            Response.Redirect(
                "NewsList.aspx");
        }
    }
}