using System;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace TraSuaNgon.Admin.Products
{
    public partial class ProductList :
        System.Web.UI.Page
    {
        ProductBLL productBLL =
            new ProductBLL();

        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            gvProducts.DataSource =
                productBLL.GetAllProductsAdmin();

            gvProducts.DataBind();
        }

        // ===========================
        // ẨN / HIỆN LẠI SẢN PHẨM
        // ===========================
        protected void gvProducts_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ToggleStatus")
            {
                int productID =
                    Convert.ToInt32(
                        e.CommandArgument);

                Product product =
                    productBLL.GetProductByIDAdmin(
                        productID);

                if (product == null)
                    return;

                // Nếu đang bán -> Ẩn
                if (product.Status)
                {
                    productBLL.DeleteProduct(
                        productID);
                }
                // Nếu đã ẩn -> Hiện lại
                else
                {
                    productBLL.RestoreProduct(
                        productID);
                }

                LoadProducts();
            }
        }
    }
}