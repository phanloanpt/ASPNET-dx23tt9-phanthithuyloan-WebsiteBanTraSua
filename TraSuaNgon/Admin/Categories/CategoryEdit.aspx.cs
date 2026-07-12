using System;
using BLL;
using Model;


namespace TraSuaNgon.Admin.Categories
{

    public partial class CategoryEdit : System.Web.UI.Page
    {


        CategoryBLL categoryBLL = new CategoryBLL();



        private int CategoryID
        {
            get
            {
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
                LoadCategory();
            }

        }





        private void LoadCategory()
        {

            Category category =
                categoryBLL.GetCategoryByID(CategoryID);



            if (category != null)
            {

                txtCategoryName.Text =
                    category.CategoryName;


                txtDescription.Text =
                    category.Description;


                ddlStatus.SelectedValue =
                    category.Status.ToString();

            }

        }







        protected void btnUpdate_Click(
            object sender,
            EventArgs e)
        {


            Category category =
                new Category();



            category.CategoryID =
                CategoryID;



            category.CategoryName =
                txtCategoryName.Text.Trim();



            category.Description =
                txtDescription.Text.Trim();



            category.Status =
                Convert.ToBoolean(
                    ddlStatus.SelectedValue);





            bool result =
                categoryBLL.UpdateCategory(category);





            if (result)
            {

                Response.Redirect(
                    "CategoryList.aspx");

            }


        }


    }

}