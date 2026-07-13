using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ToppingDAL
    {
        // Lấy tất cả topping
        public List<Topping> GetAllToppings()
        {
            List<Topping> list = new List<Topping>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT *
                    FROM Toppings
                    ORDER BY ToppingID DESC";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    Topping topping =
                        new Topping();

                    topping.ToppingID =
                        Convert.ToInt32(
                            reader["ToppingID"]);

                    topping.ToppingName =
                        reader["ToppingName"]
                        .ToString();

                    topping.Price =
                        Convert.ToDecimal(
                            reader["Price"]);

                    topping.ImageURL =
                        reader["ImageURL"]
                        .ToString();

                    topping.Status =
                        Convert.ToBoolean(
                            reader["Status"]);

                    if (reader["CreatedDate"] != DBNull.Value)
                    {
                        topping.CreatedDate =
                            Convert.ToDateTime(
                                reader["CreatedDate"]);
                    }

                    list.Add(topping);
                }
            }

            return list;
        }

        // Lấy topping theo ID
        public Topping GetToppingByID(int id)
        {
            Topping topping = null;

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql =
                    "SELECT * FROM Toppings WHERE ToppingID=@ID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@ID",
                    id);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    topping = new Topping();

                    topping.ToppingID =
                        Convert.ToInt32(
                            reader["ToppingID"]);

                    topping.ToppingName =
                        reader["ToppingName"]
                        .ToString();

                    topping.Price =
                        Convert.ToDecimal(
                            reader["Price"]);

                    topping.ImageURL =
                        reader["ImageURL"]
                        .ToString();

                    topping.Status =
                        Convert.ToBoolean(
                            reader["Status"]);

                    if (reader["CreatedDate"] != DBNull.Value)
                    {
                        topping.CreatedDate =
                            Convert.ToDateTime(
                                reader["CreatedDate"]);
                    }
                }
            }

            return topping;
        }

        // Thêm topping
        public bool InsertTopping(Topping topping)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    INSERT INTO Toppings
                    (
                        ToppingName,
                        Price,
                        ImageURL,
                        Status,
                        CreatedDate
                    )
                    VALUES
                    (
                        @ToppingName,
                        @Price,
                        @ImageURL,
                        @Status,
                        @CreatedDate
                    )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@ToppingName",
                    topping.ToppingName);

                cmd.Parameters.AddWithValue(
                    "@Price",
                    topping.Price);

                cmd.Parameters.AddWithValue(
                    "@ImageURL",
                    topping.ImageURL);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    topping.Status);

                cmd.Parameters.AddWithValue(
                    "@CreatedDate",
                    topping.CreatedDate);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật topping
        public bool UpdateTopping(Topping topping)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    UPDATE Toppings
                    SET
                        ToppingName = @ToppingName,
                        Price = @Price,
                        ImageURL = @ImageURL,
                        Status = @Status
                    WHERE ToppingID = @ToppingID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@ToppingName",
                    topping.ToppingName);

                cmd.Parameters.AddWithValue(
                    "@Price",
                    topping.Price);

                cmd.Parameters.AddWithValue(
                    "@ImageURL",
                    topping.ImageURL);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    topping.Status);

                cmd.Parameters.AddWithValue(
                    "@ToppingID",
                    topping.ToppingID);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa topping
        public bool DeleteTopping(int id)
        {
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql =
                    "DELETE FROM Toppings WHERE ToppingID=@ID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@ID",
                    id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}