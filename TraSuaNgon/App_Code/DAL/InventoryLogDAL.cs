using System.Data.SqlClient;
using Model;


namespace DAL
{
    public class InventoryLogDAL
    {

        public void Insert(
            InventoryLog log)
        {

            using (SqlConnection conn =
                Database.GetConnection())
            {

                string sql = @"

INSERT INTO InventoryLogs
(
    InventoryID,
    QuantityChanged,
    ActionType,
    Note,
    CreatedDate
)

VALUES
(
    @InventoryID,
    @QuantityChanged,
    @ActionType,
    @Note,
    GETDATE()
)

";


                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@InventoryID",
                    log.InventoryID);



                cmd.Parameters.AddWithValue(
                    "@QuantityChanged",
                    log.QuantityChanged);



                cmd.Parameters.AddWithValue(
                    "@ActionType",
                    log.ActionType);



                cmd.Parameters.AddWithValue(
                    "@Note",
                    log.Note);



                conn.Open();

                cmd.ExecuteNonQuery();

            }

        }

    }
}