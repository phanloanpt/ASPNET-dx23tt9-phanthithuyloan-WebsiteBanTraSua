using System;
using BLL;


namespace TraSuaNgon.Admin.Categories
{

    public partial class CategoryList : System.Web.UI.Page
    {


        CategoryBLL categoryBLL = new CategoryBLL();




        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                LoadCategory();
            }


        }





        // ==============================
        // LOAD DANH SÁCH DANH MỤC
        // ==============================

        private void LoadCategory()
        {

            gvCategory.DataSource =
                categoryBLL.GetCategories();


            gvCategory.DataBind();

        }







        // ==============================
        // XỬ LÝ NÚT SỬA / XÓA
        // ==============================

        protected void gvCategory_RowCommand(
            object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {


            int categoryID =
                Convert.ToInt32(
                    e.CommandArgument);





            // ==================
            // SỬA
            // ==================

            if (e.CommandName == "EditCategory")
            {

                Response.Redirect(
                    "CategoryEdit.aspx?id=" + categoryID);

            }







            // ==================
            // XÓA
            // ==================

            if (e.CommandName == "DeleteCategory")
            {


                bool result =
                    categoryBLL.DeleteCategory(categoryID);



                if (result)
                {

                    LoadCategory();

                }


            }



        }



    }

}