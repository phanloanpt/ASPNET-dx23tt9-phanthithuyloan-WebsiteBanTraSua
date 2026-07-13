using System;
using BLL;
using Model;

namespace TraSuaNgon.Admin.Products
{
    public partial class ProductAdd : System.Web.UI.Page
    {
        ProductBLL productBLL = new ProductBLL();
        CategoryBLL categoryBLL = new CategoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            ddlCategory.DataSource = categoryBLL.GetCategories();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Product p = new Product();

            p.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            p.ProductName = txtName.Text.Trim();
            p.Description = txtDescription.Text.Trim();

            // Upload ảnh
            string fileName = "";

            if (fuImage.HasFile)
            {
                fileName = fuImage.FileName;

                string savePath = Server.MapPath(
                    "~/Assets/images/products/" + fileName);

                fuImage.SaveAs(savePath);
            }

            p.ImageURL = fileName;

            p.PriceM = decimal.Parse(txtPriceM.Text);
            p.PriceL = decimal.Parse(txtPriceL.Text);

            p.IsFeatured = chkFeatured.Checked;
            p.IsNew = chkNew.Checked;
            p.IsBestSeller = chkBestSeller.Checked;
            p.Status = chkStatus.Checked;

            p.CreatedDate = DateTime.Now;

            if (productBLL.AddProduct(p))
            {
                Response.Redirect("ProductList.aspx");
            }
        }
    }
}