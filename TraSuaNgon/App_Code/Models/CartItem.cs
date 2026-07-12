using System.Collections.Generic;

namespace Model
{
    public class CartItem
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ImageURL { get; set; }

        public decimal UnitPrice { get; set; }

        public string Size { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public List<int> ToppingIDs { get; set; }

        public string ToppingNames { get; set; }
    }
}