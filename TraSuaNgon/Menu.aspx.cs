using BLL;
using System;

namespace TraSuaNgon
{
    public partial class Menu : System.Web.UI.Page
    {

        private ProductBLL productBLL = new ProductBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }



        private void LoadProducts()
        {

            string keyword = Request.QueryString["keyword"];


            if (!string.IsNullOrEmpty(keyword))
            {
                rptProducts.DataSource =
                    productBLL.SearchProducts(keyword);
            }
            else
            {
                rptProducts.DataSource =
                    productBLL.GetAllProducts();
            }


            rptProducts.DataBind();

        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string keyword = txtSearch.Text.Trim();


            if (!string.IsNullOrEmpty(keyword))
            {
                Response.Redirect("Menu.aspx?keyword=" + keyword);
            }
            else
            {
                Response.Redirect("Menu.aspx");
            }

        }


    }
}