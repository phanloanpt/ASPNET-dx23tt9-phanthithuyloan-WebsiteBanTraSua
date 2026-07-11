using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class CategoryDAL
    {
        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = "SELECT * FROM Categories WHERE Status = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Category category = new Category();

                    category.CategoryID = (int)reader["CategoryID"];
                    category.CategoryName = reader["CategoryName"].ToString();
                    category.Description = reader["Description"].ToString();
                    category.Status = (bool)reader["Status"];

                    list.Add(category);
                }
            }

            return list;
        }
    }
}