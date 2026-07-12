using System;

namespace Model
{
    public class Order
    {
        public int OrderID { get; set; }

        public int UserID { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string ShippingAddress { get; set; }

        public string Phone { get; set; }

        public string Note { get; set; }

        public string Status { get; set; }

        public string CustomerName { get; set; }

        public string ReceiverName { get; set; }
    }
}