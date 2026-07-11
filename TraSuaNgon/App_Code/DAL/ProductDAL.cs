using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ProductDAL
    {
        // ==============================
        // LẤY TẤT CẢ SẢN PHẨM
        // ==============================
        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT *
                    FROM Products
                    WHERE Status = 1
                    ORDER BY CreatedDate DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(MapProduct(reader));
                }
            }

            return list;
        }


        // ==============================
        // SẢN PHẨM NỔI BẬT
        // ==============================
        public List<Product> GetFeaturedProducts()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT TOP 4 *
                    FROM Products
                    WHERE IsFeatured = 1
                    AND Status = 1
                    ORDER BY CreatedDate DESC";


                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(MapProduct(reader));
                }
            }

            return list;
        }


        // ==============================
        // SẢN PHẨM MỚI
        // ==============================
        public List<Product> GetNewProducts()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT TOP 4 *
                    FROM Products
                    WHERE IsNew = 1
                    AND Status = 1
                    ORDER BY CreatedDate DESC";


                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(MapProduct(reader));
                }
            }

            return list;
        }



        // ==============================
        // BEST SELLER
        // ==============================
        public List<Product> GetBestSellerProducts()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT TOP 4 *
                    FROM Products
                    WHERE IsBestSeller = 1
                    AND Status = 1
                    ORDER BY CreatedDate DESC";


                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    list.Add(MapProduct(reader));
                }
            }

            return list;
        }



        // ==============================
        // TÌM KIẾM SẢN PHẨM
        // ==============================
        public List<Product> SearchProducts(string keyword)
        {
            List<Product> list = new List<Product>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();


                string sql = @"
                    SELECT *
                    FROM Products
                    WHERE ProductName LIKE @keyword
                    AND Status = 1
                    ORDER BY CreatedDate DESC";


                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue(
                    "@keyword",
                    "%" + keyword + "%"
                );


                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    list.Add(MapProduct(reader));
                }

            }

            return list;
        }




        // ==============================
        // MAP SQL → OBJECT PRODUCT
        // ==============================
        private Product MapProduct(SqlDataReader reader)
        {
            Product product = new Product();


            product.ProductID =
                Convert.ToInt32(reader["ProductID"]);


            product.CategoryID =
                Convert.ToInt32(reader["CategoryID"]);



            product.ProductName =
                reader["ProductName"].ToString();



            product.Description =
                reader["Description"] == DBNull.Value
                ? ""
                : reader["Description"].ToString();



            product.ImageURL =
                reader["ImageURL"] == DBNull.Value
                ? ""
                : reader["ImageURL"].ToString();



            product.PriceM =
                reader["PriceM"] == DBNull.Value
                ? 0
                : Convert.ToDecimal(reader["PriceM"]);



            product.PriceL =
                reader["PriceL"] == DBNull.Value
                ? 0
                : Convert.ToDecimal(reader["PriceL"]);




            product.IsFeatured =
                Convert.ToBoolean(reader["IsFeatured"]);



            product.IsNew =
                Convert.ToBoolean(reader["IsNew"]);



            product.IsBestSeller =
                Convert.ToBoolean(reader["IsBestSeller"]);



            product.Status =
                Convert.ToBoolean(reader["Status"]);




            product.CreatedDate =
                Convert.ToDateTime(reader["CreatedDate"]);



            return product;
        }
    }
}