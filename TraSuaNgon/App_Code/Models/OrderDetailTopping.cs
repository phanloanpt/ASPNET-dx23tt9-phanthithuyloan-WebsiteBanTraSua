using System;

namespace Model
{
    public class OrderDetailTopping
    {
        public int ID { get; set; }

        public int OrderDetailID { get; set; }

        public int ToppingID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}