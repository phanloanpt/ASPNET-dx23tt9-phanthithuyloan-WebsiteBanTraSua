using System.Collections.Generic;
using DAL;
using Model;


namespace BLL
{
    public class CategoryBLL
    {


        private CategoryDAL dal = new CategoryDAL();




        // ==============================
        // LẤY DANH SÁCH DANH MỤC
        // ==============================

        public List<Category> GetCategories()
        {
            return dal.GetAllCategories();
        }






        // ==============================
        // THÊM DANH MỤC
        // ==============================

        public bool AddCategory(Category category)
        {
            return dal.AddCategory(category);
        }







        // ==============================
        // XÓA DANH MỤC
        // ==============================

        public bool DeleteCategory(int categoryID)
        {
            return dal.DeleteCategory(categoryID);
        }






        // ==============================
        // LẤY 1 DANH MỤC THEO ID
        // (dùng cho trang Sửa)
        // ==============================

        public Category GetCategoryByID(int categoryID)
        {
            return dal.GetCategoryByID(categoryID);
        }






        // ==============================
        // CẬP NHẬT DANH MỤC
        // (dùng cho trang Sửa)
        // ==============================

        public bool UpdateCategory(Category category)
        {
            return dal.UpdateCategory(category);
        }



    }
}