using System;

namespace Model
{
    public class Inventory
    {
        public int InventoryID { get; set; }

        public string ItemName { get; set; }

        public string Unit { get; set; }

        public int Quantity { get; set; }

        public int MinimumQuantity { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}