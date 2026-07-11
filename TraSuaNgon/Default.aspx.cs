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

            if (data != null && data.Count > 0)
            {
                rptMainNews.DataSource = data.GetRange(0, 1);
                rptMainNews.DataBind();

                if (data.Count > 1)
                {
                    int count = Math.Min(3, data.Count - 1);

                    rptSubNews.DataSource = data.GetRange(1, count);
                    rptSubNews.DataBind();
                }
            }
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