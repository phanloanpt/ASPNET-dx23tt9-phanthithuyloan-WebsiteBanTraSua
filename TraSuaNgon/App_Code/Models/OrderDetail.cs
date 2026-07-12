using System;

namespace Model
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }
        public string ProductName { get; set; }
    }
}