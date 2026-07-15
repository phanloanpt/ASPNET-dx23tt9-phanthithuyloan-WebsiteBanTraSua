using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ReportDAL
    {
        // =========================
        // DASHBOARD
        // =========================
        public ReportModel GetDashboard()
        {
            ReportModel report =
                new ReportModel();

            using (SqlConnection conn =
                Database.GetConnection())
            {
                string sql = @"
SELECT
    COUNT(*) AS TotalOrders,

    ISNULL(
        SUM(
            CASE
                WHEN Status = N'Hoàn thành'
                THEN TotalAmount
                ELSE 0
            END
        ),0
    ) AS TotalRevenue,

    (
        SELECT COUNT(DISTINCT UserID)
        FROM Orders
        WHERE UserID IS NOT NULL
    ) AS TotalCustomers,

    SUM(
        CASE
            WHEN Status = N'Hoàn thành'
            THEN 1
            ELSE 0
        END
    ) AS CompletedOrders,

    SUM(
        CASE
            WHEN Status = N'Chờ xác nhận'
            THEN 1
            ELSE 0
        END
    ) AS PendingOrders,

    SUM(
        CASE
            WHEN Status = N'Đang pha chế'
            THEN 1
            ELSE 0
        END
    ) AS ProcessingOrders,

    SUM(
        CASE
            WHEN Status = N'Đang giao'
            THEN 1
            ELSE 0
        END
    ) AS ShippingOrders,

    SUM(
        CASE
            WHEN Status = N'Đã hủy'
            THEN 1
            ELSE 0
        END
    ) AS CancelledOrders

FROM Orders";

                SqlCommand cmd =
                    new SqlCommand(
                        sql,
                        conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    report.TotalOrders =
                        Convert.ToInt32(
                            reader["TotalOrders"]);

                    report.TotalRevenue =
                        Convert.ToDecimal(
                            reader["TotalRevenue"]);

                    report.TotalCustomers =
                        Convert.ToInt32(
                            reader["TotalCustomers"]);

                    report.CompletedOrders =
                        Convert.ToInt32(
                            reader["CompletedOrders"]);

                    report.PendingOrders =
                        Convert.ToInt32(
                            reader["PendingOrders"]);

                    report.ProcessingOrders =
                        Convert.ToInt32(
                            reader["ProcessingOrders"]);

                    report.ShippingOrders =
                        Convert.ToInt32(
                            reader["ShippingOrders"]);

                    report.CancelledOrders =
                        Convert.ToInt32(
                            reader["CancelledOrders"]);
                }
            }

            return report;
        }


        // =========================
        // TOP 5 SẢN PHẨM BÁN CHẠY
        // =========================
        public List<BestSellerModel> GetBestSeller()
        {
            List<BestSellerModel> list =
                new List<BestSellerModel>();

            using (SqlConnection conn =
                Database.GetConnection())
            {
                string sql = @"
SELECT TOP 5
    p.ProductName,
    SUM(od.Quantity) AS QuantitySold
FROM OrderDetails od
INNER JOIN Products p
    ON od.ProductID = p.ProductID
INNER JOIN Orders o
    ON od.OrderID = o.OrderID
WHERE o.Status = N'Hoàn thành'
GROUP BY p.ProductName
ORDER BY QuantitySold DESC";

                SqlCommand cmd =
                    new SqlCommand(
                        sql,
                        conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    BestSellerModel item =
                        new BestSellerModel();

                    item.ProductName =
                        reader["ProductName"]
                        .ToString();

                    item.QuantitySold =
                        Convert.ToInt32(
                            reader["QuantitySold"]);

                    list.Add(item);
                }
            }

            return list;
        }


        // =========================
        // KHO THẤP
        // =========================
        public List<LowStockModel> GetLowStock()
        {
            List<LowStockModel> list =
                new List<LowStockModel>();

            using (SqlConnection conn =
                Database.GetConnection())
            {
                string sql = @"
SELECT
    ItemName,
    Quantity,
    MinimumQuantity
FROM Inventory
WHERE Quantity <= MinimumQuantity
ORDER BY Quantity ASC";

                SqlCommand cmd =
                    new SqlCommand(
                        sql,
                        conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    LowStockModel item =
                        new LowStockModel();

                    item.ItemName =
                        reader["ItemName"]
                        .ToString();

                    item.Quantity =
                        Convert.ToInt32(
                            reader["Quantity"]);

                    item.MinimumQuantity =
                        Convert.ToInt32(
                            reader["MinimumQuantity"]);

                    list.Add(item);
                }
            }

            return list;
        }
    }
}