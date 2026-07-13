using BLL;
using System;
using System.Web.UI;

namespace TraSuaNgon
{
    public partial class Default : Page
    {
        private ProductBLL productBLL = new ProductBLL();
        private NewsBLL newsBLL = new NewsBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
                LoadNews();
            }
        }

        private void LoadProducts()
        {
            rptProducts.DataSource = productBLL.GetFeaturedProducts();
            rptProducts.DataBind();

            rptNewProducts.DataSource = productBLL.GetNewProducts();
            rptNewProducts.DataBind();

            rptBestSeller.DataSource = productBLL.GetBestSellerProducts();
            rptBestSeller.DataBind();
        }

        private void LoadNews()
        {
            var data = newsBLL.GetAllNews();

            if (data == null || data.Count == 0)
                return;


            // Tin chính: lấy tin nổi bật
            var mainNews = data.FindAll(x => x.IsFeatured);

            rptMainNews.DataSource = mainNews;
            rptMainNews.DataBind();


            // Tin phụ: lấy tin không nổi bật
            var subNews = data.FindAll(x => !x.IsFeatured);


            if (subNews.Count > 3)
            {
                subNews = subNews.GetRange(0, 3);
            }


            rptSubNews.DataSource = subNews;
            rptSubNews.DataBind();
        

            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                Response.Redirect("Menu.aspx?keyword=" + keyword);
            }
        }
    }
}