namespace Model
{
    public class ReportModel
    {
        public int TotalOrders { get; set; }

        public decimal TotalRevenue { get; set; }

        public int TotalCustomers { get; set; }

        public int CompletedOrders { get; set; }

        public int PendingOrders { get; set; }

        public int ProcessingOrders { get; set; }

        public int ShippingOrders { get; set; }

        public int CancelledOrders { get; set; }
    }
}