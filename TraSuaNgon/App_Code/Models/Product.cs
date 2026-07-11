using System;

namespace Model
{
    public class Product
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public decimal PriceM { get; set; }

        public decimal PriceL { get; set; }

        // Sản phẩm nổi bật
        public bool IsFeatured { get; set; }

        // Sản phẩm mới
        public bool IsNew { get; set; }

        // Bán chạy
        public bool IsBestSeller { get; set; }

        // Trạng thái hoạt động
        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}