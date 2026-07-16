using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ProductDAL
    {
        // Lấy tất cả sản phẩm đang bán
        public List<Product> GetAllProducts()
        {
            List<Product> list =
                new List<Product>();

            using (SqlConnection conn =
                DBHelper.GetConnection())
            {
                string query = @"
                    SELECT p.*, c.CategoryName
                    FROM Products p
                    LEFT JOIN Categories c
                    ON p.CategoryID = c.CategoryID
                    WHERE p.Status = 1
                    ORDER BY p.ProductID DESC";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p =
                        new Product();

                    p.ProductID =
                        Convert.ToInt32(
                            reader["ProductID"]);

                    p.CategoryID =
                        Convert.ToInt32(
                            reader["CategoryID"]);

                    p.CategoryName =
                        reader["CategoryName"]
                        .ToString();

                    p.ProductName =
                        reader["ProductName"]
                        .ToString();

                    p.Description =
                        reader["Description"]
                        .ToString();

                    p.ImageURL =
                        reader["ImageURL"]
                        .ToString();

                    p.PriceM =
                        Convert.ToDecimal(
                            reader["PriceM"]);

                    p.PriceL =
                        Convert.ToDecimal(
                            reader["PriceL"]);

                    p.IsFeatured =
                        Convert.ToBoolean(
                            reader["IsFeatured"]);

                    p.IsNew =
                        Convert.ToBoolean(
                            reader["IsNew"]);

                    p.IsBestSeller =
                        Convert.ToBoolean(
                            reader["IsBestSeller"]);

                    p.Status =
                        Convert.ToBoolean(
                            reader["Status"]);

                    if (reader["CreatedDate"]
                        != DBNull.Value)
                    {
                        p.CreatedDate =
                            Convert.ToDateTime(
                                reader["CreatedDate"]);
                    }

                    list.Add(p);
                }

                conn.Close();
            }

            return list;
        }

        // Lấy theo ID
        public Product GetProductByID(
            int productID)
        {
            Product p = null;

            using (SqlConnection conn =
                DBHelper.GetConnection())
            {
                string query =
                    @"SELECT *
                      FROM Products
                      WHERE ProductID=@ProductID";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn);

                cmd.Parameters.AddWithValue(
                    "@ProductID",
                    productID);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    p = new Product();

                    p.ProductID =
                        Convert.ToInt32(
                            reader["ProductID"]);

                    p.CategoryID =
                        Convert.ToInt32(
                            reader["CategoryID"]);

                    p.ProductName =
                        reader["ProductName"]
                        .ToString();

                    p.Description =
                        reader["Description"]
                        .ToString();

                    p.ImageURL =
                        reader["ImageURL"]
                        .ToString();

                    p.PriceM =
                        Convert.ToDecimal(
                            reader["PriceM"]);

                    p.PriceL =
                        Convert.ToDecimal(
                            reader["PriceL"]);

                    p.IsFeatured =
                        Convert.ToBoolean(
                            reader["IsFeatured"]);

                    p.IsNew =
                        Convert.ToBoolean(
                            reader["IsNew"]);

                    p.IsBestSeller =
                        Convert.ToBoolean(
                            reader["IsBestSeller"]);

                    p.Status =
                        Convert.ToBoolean(
                            reader["Status"]);

                    if (reader["CreatedDate"]
                        != DBNull.Value)
                    {
                        p.CreatedDate =
                            Convert.ToDateTime(
                                reader["CreatedDate"]);
                    }
                }

                conn.Close();
            }

            return p;
        }

        // Thêm sản phẩm
        public bool InsertProduct(
            Product p)
        {
            using (SqlConnection conn =
                DBHelper.GetConnection())
            {
                string query = @"
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
                        @CreatedDate
                    )";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn);

                cmd.Parameters.AddWithValue(
                    "@CategoryID",
                    p.CategoryID);

                cmd.Parameters.AddWithValue(
                    "@ProductName",
                    p.ProductName);

                cmd.Parameters.AddWithValue(
                    "@Description",
                    p.Description);

                cmd.Parameters.AddWithValue(
                    "@ImageURL",
                    p.ImageURL);

                cmd.Parameters.AddWithValue(
                    "@PriceM",
                    p.PriceM);

                cmd.Parameters.AddWithValue(
                    "@PriceL",
                    p.PriceL);

                cmd.Parameters.AddWithValue(
                    "@IsFeatured",
                    p.IsFeatured);

                cmd.Parameters.AddWithValue(
                    "@IsNew",
                    p.IsNew);

                cmd.Parameters.AddWithValue(
                    "@IsBestSeller",
                    p.IsBestSeller);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    p.Status);

                cmd.Parameters.AddWithValue(
                    "@CreatedDate",
                    p.CreatedDate ?? DateTime.Now);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật sản phẩm
        public bool UpdateProduct(
            Product p)
        {
            using (SqlConnection conn =
                DBHelper.GetConnection())
            {
                string query = @"
                    UPDATE Products SET
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
                    new SqlCommand(
                        query,
                        conn);

                cmd.Parameters.AddWithValue(
                    "@CategoryID",
                    p.CategoryID);

                cmd.Parameters.AddWithValue(
                    "@ProductName",
                    p.ProductName);

                cmd.Parameters.AddWithValue(
                    "@Description",
                    p.Description);

                cmd.Parameters.AddWithValue(
                    "@ImageURL",
                    p.ImageURL);

                cmd.Parameters.AddWithValue(
                    "@PriceM",
                    p.PriceM);

                cmd.Parameters.AddWithValue(
                    "@PriceL",
                    p.PriceL);

                cmd.Parameters.AddWithValue(
                    "@IsFeatured",
                    p.IsFeatured);

                cmd.Parameters.AddWithValue(
                    "@IsNew",
                    p.IsNew);

                cmd.Parameters.AddWithValue(
                    "@IsBestSeller",
                    p.IsBestSeller);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    p.Status);

                cmd.Parameters.AddWithValue(
                    "@ProductID",
                    p.ProductID);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa mềm
        public bool DeleteProduct(
            int productID)
        {
            using (SqlConnection conn =
                DBHelper.GetConnection())
            {
                string query = @"
                    UPDATE Products
                    SET Status = 0
                    WHERE ProductID = @ProductID";

                SqlCommand cmd =
                    new SqlCommand(
                        query,
                        conn);

                cmd.Parameters.AddWithValue(
                    "@ProductID",
                    productID);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<Product> GetAllProductsAdmin()
        {
            List<Product> list =
                new List<Product>();

            using (SqlConnection conn =
                DBHelper.GetConnection())
            {
                string query = @"
        SELECT p.*, c.CategoryName
        FROM Products p
        LEFT JOIN Categories c
        ON p.CategoryID = c.CategoryID
        ORDER BY p.ProductID DESC";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product p =
                        new Product();

                    p.ProductID =
                        Convert.ToInt32(
                            reader["ProductID"]);

                    p.CategoryID =
                        Convert.ToInt32(
                            reader["CategoryID"]);

                    p.CategoryName =
                        reader["CategoryName"]
                        .ToString();

                    p.ProductName =
                        reader["ProductName"]
                        .ToString();

                    p.Description =
                        reader["Description"]
                        .ToString();

                    p.ImageURL =
                        reader["ImageURL"]
                        .ToString();

                    p.PriceM =
                        Convert.ToDecimal(
                            reader["PriceM"]);

                    p.PriceL =
                        Convert.ToDecimal(
                            reader["PriceL"]);

                    p.IsFeatured =
                        Convert.ToBoolean(
                            reader["IsFeatured"]);

                    p.IsNew =
                        Convert.ToBoolean(
                            reader["IsNew"]);

                    p.IsBestSeller =
                        Convert.ToBoolean(
                            reader["IsBestSeller"]);

                    p.Status =
                        Convert.ToBoolean(
                            reader["Status"]);

                    list.Add(p);
                }
            }

            return list;
        }

        // Tìm kiếm
        public List<Product> SearchProducts(
            string keyword)
        {
            List<Product> list =
                GetAllProducts();

            return list.FindAll(x =>
                x.ProductName
                .ToLower()
                .Contains(
                    keyword.ToLower()));
        }

        // Sản phẩm nổi bật
        public List<Product> GetFeaturedProducts()
        {
            List<Product> list =
                GetAllProducts();

            return list.FindAll(x =>
                x.IsFeatured);
        }

        // Sản phẩm mới
        public List<Product> GetNewProducts()
        {
            List<Product> list =
                GetAllProducts();

            return list.FindAll(x =>
                x.IsNew);
        }

        // Best Seller
        public List<Product> GetBestSellerProducts()
        {
            List<Product> list =
                GetAllProducts();

            return list.FindAll(x =>
                x.IsBestSeller);
        }

        // Lọc theo danh mục
        public List<Product> GetProductsByCategory(
            int id)
        {
            List<Product> list =
                GetAllProducts();

            return list.FindAll(x =>
                x.CategoryID == id);
        }
        public bool RestoreProduct(int productID)
        {
            using (SqlConnection conn =
                DBHelper.GetConnection())
            {
                string query = @"
            UPDATE Products
            SET Status = 1
            WHERE ProductID = @ProductID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@ProductID",
                    productID);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}