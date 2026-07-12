using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class OrderBLL
    {

        private OrderDAL orderDAL = new OrderDAL();



        // Tạo đơn hàng
        public int CreateOrder(Order order)
        {
            return orderDAL.InsertOrder(order);
        }



        // Thêm chi tiết đơn hàng
        public int AddOrderDetail(OrderDetail detail)
        {
            return orderDAL.InsertOrderDetail(detail);
        }



        // Thêm topping
        public bool AddOrderDetailTopping(OrderDetailTopping topping)
        {
            return orderDAL.InsertOrderDetailTopping(topping);
        }



        // Danh sách đơn hàng
        public List<Order> GetAllOrders()
        {
            return orderDAL.GetAllOrders();
        }



        // Lấy đơn hàng theo ID
        public Order GetOrderByID(int orderID)
        {
            return orderDAL.GetOrderByID(orderID);
        }



        // Lấy danh sách sản phẩm trong đơn
        public List<OrderDetail> GetOrderDetails(int orderID)
        {
            return orderDAL.GetOrderDetails(orderID);
        }



        // Cập nhật trạng thái
        public bool UpdateStatus(
            int orderID,
            string status)
        {
            return orderDAL.UpdateStatus(
                orderID,
                status);
        }


    }
}