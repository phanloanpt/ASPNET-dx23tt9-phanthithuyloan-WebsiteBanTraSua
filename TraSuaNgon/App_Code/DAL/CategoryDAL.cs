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

                string sql = @"
                    SELECT 
                        CategoryID,
                        CategoryName,
                        Description,
                        Status
                    FROM Categories
                    WHERE Status = 1";


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





        public bool AddCategory(Category category)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();


                string sql = @"
                    INSERT INTO Categories
                    (
                        CategoryName,
                        Description,
                        Status
                    )
                    VALUES
                    (
                        @CategoryName,
                        @Description,
                        @Status
                    )";


                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue(
                    "@CategoryName",
                    category.CategoryName);


                cmd.Parameters.AddWithValue(
                    "@Description",
                    category.Description);


                cmd.Parameters.AddWithValue(
                    "@Status",
                    category.Status);



                return cmd.ExecuteNonQuery() > 0;
            }
        }







        public bool DeleteCategory(int categoryID)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();


                string sql =
                    "DELETE FROM Categories WHERE CategoryID=@CategoryID";


                SqlCommand cmd =
                    new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue(
                    "@CategoryID",
                    categoryID);



                return cmd.ExecuteNonQuery() > 0;
            }
        }







        public Category GetCategoryByID(int categoryID)
        {
            Category category = null;


            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();


                string sql = @"
                    SELECT 
                        CategoryID,
                        CategoryName,
                        Description,
                        Status
                    FROM Categories
                    WHERE CategoryID=@CategoryID";


                SqlCommand cmd =
                    new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue(
                    "@CategoryID",
                    categoryID);



                SqlDataReader reader =
                    cmd.ExecuteReader();



                if (reader.Read())
                {
                    category = new Category();

                    category.CategoryID =
                        (int)reader["CategoryID"];


                    category.CategoryName =
                        reader["CategoryName"].ToString();


                    category.Description =
                        reader["Description"].ToString();


                    category.Status =
                        (bool)reader["Status"];
                }

            }


            return category;
        }








        public bool UpdateCategory(Category category)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();


                string sql = @"
                    UPDATE Categories
                    SET
                        CategoryName=@CategoryName,
                        Description=@Description,
                        Status=@Status
                    WHERE CategoryID=@CategoryID";


                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@CategoryID",
                    category.CategoryID);


                cmd.Parameters.AddWithValue(
                    "@CategoryName",
                    category.CategoryName);


                cmd.Parameters.AddWithValue(
                    "@Description",
                    category.Description);


                cmd.Parameters.AddWithValue(
                    "@Status",
                    category.Status);



                return cmd.ExecuteNonQuery() > 0;
            }
        }


    }
}