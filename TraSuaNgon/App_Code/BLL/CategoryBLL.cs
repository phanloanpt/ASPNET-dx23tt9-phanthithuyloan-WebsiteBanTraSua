using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class CategoryBLL
    {
        private CategoryDAL dal = new CategoryDAL();

        public List<Category> GetCategories()
        {
            return dal.GetAllCategories();
        }
    }
}