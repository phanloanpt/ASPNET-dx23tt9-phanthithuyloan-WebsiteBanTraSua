using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ToppingDAL
    {
        // Lấy tất cả topping đang hoạt động
        public List<Topping> GetAllToppings()
        {
            List<Topping> list = new List<Topping>();

            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();

                string sql = @"
                    SELECT *
                    FROM Toppings
                    WHERE Status = 1
                    ORDER BY ToppingName";

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

                    topping.CreatedDate =
                        Convert.ToDateTime(
                            reader["CreatedDate"]);

                    list.Add(topping);
                }
            }

            return list;
        }
    }
}