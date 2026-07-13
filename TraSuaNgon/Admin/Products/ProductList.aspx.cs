using System;
using BLL;

namespace TraSuaNgon.Admin.Products
{
    public partial class ProductList : System.Web.UI.Page
    {
        ProductBLL productBLL = new ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
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

        protected void gvProducts_RowDeleting(
            object sender,
            System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int productID =
                Convert.ToInt32(
                    gvProducts.DataKeys[e.RowIndex].Value);

            productBLL.DeleteProduct(productID);

            LoadProducts();
        }
    }
}