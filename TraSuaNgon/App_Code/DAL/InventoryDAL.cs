using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Model;


namespace DAL
{
    public class InventoryDAL
    {

        private string connectionString =
            ConfigurationManager
            .ConnectionStrings["TraSuaNgonConnection"]
            .ConnectionString;



        public List<Inventory> GetAll()
        {

            List<Inventory> list =
                new List<Inventory>();


            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {


                string sql =
                @"SELECT 
                    InventoryID,
                    ItemName,
                    Unit,
                    Quantity,
                    MinimumQuantity,
                    UpdatedDate
                  FROM Inventory
                  ORDER BY InventoryID ASC";


                SqlCommand cmd =
                    new SqlCommand(sql, conn);


                conn.Open();


                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {

                    Inventory item =
                        new Inventory();


                    item.InventoryID =
                        Convert.ToInt32(
                            reader["InventoryID"]);



                    item.ItemName =
                        reader["ItemName"].ToString();



                    item.Unit =
                        reader["Unit"].ToString();



                    item.Quantity =
                        Convert.ToInt32(
                            reader["Quantity"]);



                    item.MinimumQuantity =
                        Convert.ToInt32(
                            reader["MinimumQuantity"]);



                    item.UpdatedDate =
                        Convert.ToDateTime(
                            reader["UpdatedDate"]);



                    list.Add(item);

                }

            }


            return list;

        }

        public Inventory GetByName(string name)
        {
            Inventory item = null;

            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"
        SELECT *
        FROM Inventory
        WHERE ItemName = @ItemName";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@ItemName",
                    name);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    item = new Inventory();

                    item.InventoryID =
                        Convert.ToInt32(
                            reader["InventoryID"]);

                    item.ItemName =
                        reader["ItemName"].ToString();

                    item.Unit =
                        reader["Unit"].ToString();

                    item.Quantity =
                        Convert.ToInt32(
                            reader["Quantity"]);

                    item.MinimumQuantity =
                        Convert.ToInt32(
                            reader["MinimumQuantity"]);
                }
            }

            return item;
        }
        public void UpdateQuantity(
    int inventoryID,
    int quantity)
        {
            using (SqlConnection conn =
                Database.GetConnection())
            {
                string sql = @"
        UPDATE Inventory
        SET Quantity = @Quantity,
            UpdatedDate = GETDATE()
        WHERE InventoryID = @InventoryID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@Quantity",
                    quantity);

                cmd.Parameters.AddWithValue(
                    "@InventoryID",
                    inventoryID);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public void Export(
    int inventoryID,
    int quantity)
        {
            using (SqlConnection conn =
                Database.GetConnection())
            {
                string sql = @"
        UPDATE Inventory
        SET Quantity = Quantity - @Quantity,
            UpdatedDate = GETDATE()
        WHERE InventoryID = @InventoryID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@Quantity",
                    quantity);

                cmd.Parameters.AddWithValue(
                    "@InventoryID",
                    inventoryID);

                conn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}