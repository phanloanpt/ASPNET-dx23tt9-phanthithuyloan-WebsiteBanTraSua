using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class OrderDAL
    {


        // =====================================
        // INSERT ORDER
        // =====================================

        public int InsertOrder(Order order)
        {

            int orderID = 0;


            using (SqlConnection conn = Database.GetConnection())
            {

                string sql = @"

                INSERT INTO Orders
                (
                    UserID,
                    OrderDate,
                    TotalAmount,
                    ShippingAddress,
                    Phone,
                    Note,
                    Status,
                    CustomerName,
                    ReceiverName
                )

                VALUES
                (
                    @UserID,
                    @OrderDate,
                    @TotalAmount,
                    @ShippingAddress,
                    @Phone,
                    @Note,
                    @Status,
                    @CustomerName,
                    @ReceiverName
                );


                SELECT SCOPE_IDENTITY();

                ";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@UserID",
                    order.UserID);



                cmd.Parameters.AddWithValue(
                    "@OrderDate",
                    order.OrderDate);



                cmd.Parameters.AddWithValue(
                    "@TotalAmount",
                    order.TotalAmount);



                cmd.Parameters.AddWithValue(
                    "@ShippingAddress",
                    order.ShippingAddress);



                cmd.Parameters.AddWithValue(
                    "@Phone",
                    order.Phone);



                cmd.Parameters.AddWithValue(
                    "@Note",
                    order.Note ?? "");



                cmd.Parameters.AddWithValue(
                    "@Status",
                    order.Status);



                cmd.Parameters.AddWithValue(
                    "@CustomerName",
                    order.CustomerName);



                cmd.Parameters.AddWithValue(
                    "@ReceiverName",
                    order.ReceiverName);



                conn.Open();



                orderID =
                    Convert.ToInt32(
                        cmd.ExecuteScalar());

            }


            return orderID;

        }








        // =====================================
        // INSERT ORDER DETAIL
        // SubTotal là computed column
        // SQL Server tự tính
        // =====================================

        public int InsertOrderDetail(
            OrderDetail detail)
        {

            int orderDetailID = 0;


            using (SqlConnection conn = Database.GetConnection())
            {

                string sql = @"

                INSERT INTO OrderDetails
                (
                    OrderID,
                    ProductID,
                    Quantity,
                    Size,
                    UnitPrice
                )

                VALUES
                (
                    @OrderID,
                    @ProductID,
                    @Quantity,
                    @Size,
                    @UnitPrice
                );


                SELECT SCOPE_IDENTITY();

                ";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);





                cmd.Parameters.AddWithValue(
                    "@OrderID",
                    detail.OrderID);



                cmd.Parameters.AddWithValue(
                    "@ProductID",
                    detail.ProductID);



                cmd.Parameters.AddWithValue(
                    "@Quantity",
                    detail.Quantity);



                cmd.Parameters.AddWithValue(
                    "@Size",
                    detail.Size);



                cmd.Parameters.AddWithValue(
                    "@UnitPrice",
                    detail.UnitPrice);



                conn.Open();



                orderDetailID =
                    Convert.ToInt32(
                        cmd.ExecuteScalar());

            }



            return orderDetailID;

        }









        // =====================================
        // INSERT TOPPING
        // =====================================

        public bool InsertOrderDetailTopping(
            OrderDetailTopping topping)
        {


            using (SqlConnection conn = Database.GetConnection())
            {

                string sql = @"

                INSERT INTO OrderDetailToppings
                (
                    OrderDetailID,
                    ToppingID,
                    Quantity,
                    Price
                )

                VALUES
                (
                    @OrderDetailID,
                    @ToppingID,
                    @Quantity,
                    @Price
                )

                ";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@OrderDetailID",
                    topping.OrderDetailID);



                cmd.Parameters.AddWithValue(
                    "@ToppingID",
                    topping.ToppingID);



                cmd.Parameters.AddWithValue(
                    "@Quantity",
                    topping.Quantity);



                cmd.Parameters.AddWithValue(
                    "@Price",
                    topping.Price);



                conn.Open();



                return cmd.ExecuteNonQuery() > 0;

            }

        }









        // =====================================
        // ADMIN - LẤY DANH SÁCH ĐƠN
        // =====================================

        public List<Order> GetAllOrders()
        {

            List<Order> list =
                new List<Order>();


            using (SqlConnection conn = Database.GetConnection())
            {

                string sql = @"

                SELECT *
                FROM Orders
                ORDER BY OrderDate DESC

                ";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                conn.Open();



                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {

                    Order order =
                        new Order();


                    order.OrderID =
                        Convert.ToInt32(
                            reader["OrderID"]);



                    order.UserID =
                        Convert.ToInt32(
                            reader["UserID"]);



                    order.CustomerName =
                        reader["CustomerName"].ToString();



                    order.ReceiverName =
                        reader["ReceiverName"].ToString();



                    order.Phone =
                        reader["Phone"].ToString();



                    order.TotalAmount =
                        Convert.ToDecimal(
                            reader["TotalAmount"]);



                    order.Status =
                        reader["Status"].ToString();



                    order.OrderDate =
                        Convert.ToDateTime(
                            reader["OrderDate"]);



                    list.Add(order);

                }

            }



            return list;

        }









        // =====================================
        // ADMIN UPDATE STATUS
        // =====================================

        public bool UpdateStatus(
            int orderID,
            string status)
        {


            using (SqlConnection conn = Database.GetConnection())
            {

                string sql = @"

                UPDATE Orders

                SET Status=@Status

                WHERE OrderID=@OrderID

                ";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@Status",
                    status);



                cmd.Parameters.AddWithValue(
                    "@OrderID",
                    orderID);



                conn.Open();



                return cmd.ExecuteNonQuery() > 0;

            }
        }
            public Order GetOrderByID(int orderID)
        {
            Order order = null;


            using (SqlConnection conn = Database.GetConnection())
            {
                string sql = @"
            SELECT *
            FROM Orders
            WHERE OrderID = @OrderID";


                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@OrderID",
                    orderID);


                conn.Open();


                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    order = new Order();

                    order.OrderID =
                        Convert.ToInt32(reader["OrderID"]);


                    order.CustomerName =
                        reader["CustomerName"].ToString();


                    order.Phone =
                        reader["Phone"].ToString();


                    order.ShippingAddress =
                        reader["ShippingAddress"].ToString();


                    order.Status =
                        reader["Status"].ToString();


                    order.TotalAmount =
                        Convert.ToDecimal(reader["TotalAmount"]);


                    order.OrderDate =
                        Convert.ToDateTime(reader["OrderDate"]);
                }
            }


            return order;
        }
        public List<OrderDetail> GetOrderDetails(int orderID)
        {

            List<OrderDetail> list =
                new List<OrderDetail>();


            using (SqlConnection conn = Database.GetConnection())
            {

                string sql = @"

        SELECT
            od.OrderDetailID,
            od.OrderID,
            od.ProductID,
            od.Quantity,
            od.Size,
            od.UnitPrice,
            od.SubTotal,

            p.ProductName,

            STRING_AGG(t.ToppingName, ', ') 
            AS ToppingName


        FROM OrderDetails od


        INNER JOIN Products p
        ON od.ProductID = p.ProductID


        LEFT JOIN OrderDetailToppings odt
        ON od.OrderDetailID = odt.OrderDetailID


        LEFT JOIN Toppings t
        ON odt.ToppingID = t.ToppingID


        WHERE od.OrderID=@OrderID


        GROUP BY
            od.OrderDetailID,
            od.OrderID,
            od.ProductID,
            od.Quantity,
            od.Size,
            od.UnitPrice,
            od.SubTotal,
            p.ProductName

        ";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@OrderID",
                    orderID);



                conn.Open();



                SqlDataReader reader =
                    cmd.ExecuteReader();



                while (reader.Read())
                {


                    OrderDetail detail =
                        new OrderDetail();



                    detail.OrderDetailID =
                        Convert.ToInt32(
                            reader["OrderDetailID"]);



                    detail.OrderID =
                        Convert.ToInt32(
                            reader["OrderID"]);



                    detail.ProductID =
                        Convert.ToInt32(
                            reader["ProductID"]);



                    detail.Quantity =
                        Convert.ToInt32(
                            reader["Quantity"]);



                    detail.Size =
                        reader["Size"].ToString();



                    detail.UnitPrice =
                        Convert.ToDecimal(
                            reader["UnitPrice"]);



                    detail.SubTotal =
                        Convert.ToDecimal(
                            reader["SubTotal"]);



                    detail.ProductName =
                        reader["ProductName"].ToString();



                    detail.ToppingName =
                        reader["ToppingName"] == DBNull.Value
                        ?
                        ""
                        :
                        reader["ToppingName"].ToString();



                    list.Add(detail);


                }


            }



            return list;

        }




    }
}