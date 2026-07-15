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

    }
}