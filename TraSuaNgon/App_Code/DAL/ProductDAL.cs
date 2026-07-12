using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;


namespace DAL
{
    public class ProductDAL
    {



        // =====================================
        // FRONTEND
        // LẤY SẢN PHẨM ĐANG HOẠT ĐỘNG
        // =====================================

        public List<Product> GetAllProducts()
        {

            List<Product> list =
                new List<Product>();


            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                SELECT *
                FROM Products
                WHERE Status = 1
                ORDER BY CreatedDate DESC";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {

                    list.Add(
                        MapProduct(reader)
                    );

                }


            }


            return list;

        }






        // =====================================
        // SẢN PHẨM NỔI BẬT
        // =====================================

        public List<Product> GetFeaturedProducts()
        {

            List<Product> list =
                new List<Product>();


            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                SELECT TOP 4 *
                FROM Products
                WHERE IsFeatured = 1
                AND Status = 1
                ORDER BY CreatedDate DESC";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {

                    list.Add(
                        MapProduct(reader)
                    );

                }

            }


            return list;

        }






        // =====================================
        // SẢN PHẨM MỚI
        // =====================================

        public List<Product> GetNewProducts()
        {

            List<Product> list =
                new List<Product>();


            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                SELECT TOP 4 *
                FROM Products
                WHERE IsNew = 1
                AND Status = 1
                ORDER BY CreatedDate DESC";


                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {

                    list.Add(
                        MapProduct(reader)
                    );

                }

            }


            return list;

        }






        // =====================================
        // BEST SELLER
        // =====================================

        public List<Product> GetBestSellerProducts()
        {

            List<Product> list =
                new List<Product>();


            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                SELECT TOP 4 *
                FROM Products
                WHERE IsBestSeller = 1
                AND Status = 1
                ORDER BY CreatedDate DESC";


                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {

                    list.Add(
                        MapProduct(reader)
                    );

                }

            }


            return list;

        }







        // =====================================
        // SEARCH
        // =====================================

        public List<Product> SearchProducts(
            string keyword)
        {

            List<Product> list =
                new List<Product>();


            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                SELECT *
                FROM Products
                WHERE ProductName LIKE @keyword
                AND Status = 1";


                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@keyword",
                    "%" + keyword + "%"
                );



                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {

                    list.Add(
                        MapProduct(reader)
                    );

                }

            }


            return list;

        }







        // =====================================
        // CHI TIẾT SẢN PHẨM
        // =====================================

        public Product GetProductByID(
            int id)
        {

            Product product = null;


            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                SELECT *
                FROM Products
                WHERE ProductID=@ID
                AND Status=1";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@ID",
                    id);



                SqlDataReader reader =
                    cmd.ExecuteReader();



                if (reader.Read())
                {

                    product =
                        MapProduct(reader);

                }

            }


            return product;

        }






        // =====================================
        // ADMIN
        // LẤY TẤT CẢ SẢN PHẨM
        // =====================================

        public List<Product> GetAllProductsAdmin()
        {

            List<Product> list =
                new List<Product>();


            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                SELECT 
                    p.*,
                    c.CategoryName

                FROM Products p

                INNER JOIN Categories c
                ON p.CategoryID=c.CategoryID

                ORDER BY p.CreatedDate DESC";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {

                    Product product =
                        MapProduct(reader);



                    product.CategoryName =
                        reader["CategoryName"].ToString();



                    list.Add(product);

                }

            }


            return list;

        }






        // =====================================
        // ADMIN GET BY ID
        // =====================================

        public Product GetProductByIDAdmin(
            int id)
        {

            Product product = null;


            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                SELECT *
                FROM Products
                WHERE ProductID=@ID";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@ID",
                    id);



                SqlDataReader reader =
                    cmd.ExecuteReader();



                if (reader.Read())
                {
                    product =
                        MapProduct(reader);
                }

            }


            return product;

        }






        // =====================================
        // ADD PRODUCT
        // =====================================

        public bool AddProduct(
            Product product)
        {

            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                INSERT INTO Products
                (
                    CategoryID,
                    ProductName,
                    Description,
                    ImageURL,
                    PriceM,
                    PriceL,
                    IsFeatured,
                    IsNew,
                    IsBestSeller,
                    Status,
                    CreatedDate
                )

                VALUES
                (
                    @CategoryID,
                    @ProductName,
                    @Description,
                    @ImageURL,
                    @PriceM,
                    @PriceL,
                    @IsFeatured,
                    @IsNew,
                    @IsBestSeller,
                    @Status,
                    GETDATE()
                )";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                AddParameter(cmd, product);



                return cmd.ExecuteNonQuery() > 0;

            }

        }






        // =====================================
        // UPDATE PRODUCT
        // =====================================

        public bool UpdateProduct(
            Product product)
        {

            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                UPDATE Products

                SET

                CategoryID=@CategoryID,
                ProductName=@ProductName,
                Description=@Description,
                ImageURL=@ImageURL,
                PriceM=@PriceM,
                PriceL=@PriceL,
                IsFeatured=@IsFeatured,
                IsNew=@IsNew,
                IsBestSeller=@IsBestSeller,
                Status=@Status

                WHERE ProductID=@ProductID";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@ProductID",
                    product.ProductID);



                AddParameter(cmd, product);



                return cmd.ExecuteNonQuery() > 0;

            }

        }






        // =====================================
        // DELETE
        // =====================================

        public bool DeleteProduct(
            int id)
        {

            using (SqlConnection conn = Database.GetConnection())
            {

                conn.Open();


                string sql = @"
                UPDATE Products
                SET Status=0
                WHERE ProductID=@ID";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@ID",
                    id);



                return cmd.ExecuteNonQuery() > 0;

            }

        }







        // =====================================
        // MAP DATA
        // =====================================

        private Product MapProduct(
            SqlDataReader reader)
        {

            Product product =
                new Product();



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
                Convert.ToDecimal(reader["PriceM"]);



            product.PriceL =
                Convert.ToDecimal(reader["PriceL"]);



            product.IsFeatured =
                Convert.ToBoolean(reader["IsFeatured"]);



            product.IsNew =
                Convert.ToBoolean(reader["IsNew"]);



            product.IsBestSeller =
                Convert.ToBoolean(reader["IsBestSeller"]);



            product.Status =
                Convert.ToBoolean(reader["Status"]);



            product.CreatedDate =
                reader["CreatedDate"] == DBNull.Value
                ? null
                : (DateTime?)Convert.ToDateTime(reader["CreatedDate"]);



            return product;

        }






        private void AddParameter(
            SqlCommand cmd,
            Product product)
        {

            cmd.Parameters.AddWithValue(
                "@CategoryID",
                product.CategoryID);


            cmd.Parameters.AddWithValue(
                "@ProductName",
                product.ProductName);


            cmd.Parameters.AddWithValue(
                "@Description",
                product.Description ?? "");


            cmd.Parameters.AddWithValue(
                "@ImageURL",
                product.ImageURL ?? "");


            cmd.Parameters.AddWithValue(
                "@PriceM",
                product.PriceM);


            cmd.Parameters.AddWithValue(
                "@PriceL",
                product.PriceL);


            cmd.Parameters.AddWithValue(
                "@IsFeatured",
                product.IsFeatured);


            cmd.Parameters.AddWithValue(
                "@IsNew",
                product.IsNew);


            cmd.Parameters.AddWithValue(
                "@IsBestSeller",
                product.IsBestSeller);


            cmd.Parameters.AddWithValue(
                "@Status",
                product.Status);

        }

        // ==============================
        // LẤY SẢN PHẨM THEO DANH MỤC
        // ==============================
        public List<Product> GetProductsByCategory(int categoryId)
        {
            List<Product> list = new List<Product>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
            SELECT *
            FROM Products
            WHERE CategoryID = @CategoryID
            AND Status = 1
            ORDER BY CreatedDate DESC";


                SqlCommand cmd = new SqlCommand(sql, conn);


                cmd.Parameters.AddWithValue(
                    "@CategoryID",
                    categoryId
                );


                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    list.Add(MapProduct(reader));
                }
            }


            return list;
        }
    }
}