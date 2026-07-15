using System;

namespace Model
{
    public class InventoryLog
    {
        public int LogID { get; set; }

        public int InventoryID { get; set; }

        public int QuantityChanged { get; set; }

        public string ActionType { get; set; }

        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}