using BLL;
using System;

namespace TraSuaNgon
{
    public partial class Menu : System.Web.UI.Page
    {

        private ProductBLL productBLL = new ProductBLL();

        // Thêm quản lý topping
        private ToppingBLL toppingBLL = new ToppingBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();

                // Load topping ở cuối menu
                LoadToppings();
            }
        }



        // ==========================
        // LOAD SẢN PHẨM
        // ==========================
        private void LoadProducts()
        {
            string keyword = Request.QueryString["keyword"];
            string category = Request.QueryString["category"];


            if (!string.IsNullOrEmpty(keyword))
            {
                rptProducts.DataSource =
                    productBLL.SearchProducts(keyword);
            }
            else if (!string.IsNullOrEmpty(category))
            {
                int categoryId;

                if (int.TryParse(category, out categoryId))
                {
                    rptProducts.DataSource =
                        productBLL.GetProductsByCategory(categoryId);
                }
                else
                {
                    rptProducts.DataSource =
                        productBLL.GetAllProducts();
                }
            }
            else
            {
                rptProducts.DataSource =
                    productBLL.GetAllProducts();
            }


            rptProducts.DataBind();
        }



        // ==========================
        // LOAD TOPPING
        // ==========================
        private void LoadToppings()
        {
            rptToppings.DataSource =
                toppingBLL.GetAllToppings();

            rptToppings.DataBind();
        }




        // ==========================
        // TÌM KIẾM
        // ==========================
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string keyword = txtSearch.Text.Trim();


            if (!string.IsNullOrEmpty(keyword))
            {
                Response.Redirect(
                    "Menu.aspx?keyword=" + keyword);
            }
            else
            {
                Response.Redirect("Menu.aspx");
            }

        }

    }
}