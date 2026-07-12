using System;
using BLL;
using Model;


namespace TraSuaNgon.Admin.Categories
{
    public partial class CategoryAdd : System.Web.UI.Page
    {

        CategoryBLL categoryBLL = new CategoryBLL();



        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {

            Category category = new Category();


            category.CategoryName =
                txtCategoryName.Text.Trim();



            category.Description =
                txtDescription.Text.Trim();



            category.Status =
                Convert.ToBoolean(
                    ddlStatus.SelectedValue);



            categoryBLL.AddCategory(category);



            Response.Redirect(
                "CategoryList.aspx");

        }


    }
}