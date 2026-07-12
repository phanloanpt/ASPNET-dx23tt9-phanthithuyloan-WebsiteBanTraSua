using System;

namespace Model
{
    public class Product
    {


        // =========================
        // KHÓA CHÍNH
        // =========================

        public int ProductID { get; set; }



        // =========================
        // DANH MỤC
        // =========================

        public int CategoryID { get; set; }


        // Dùng khi JOIN Categories
        public string CategoryName { get; set; }





        // =========================
        // THÔNG TIN SẢN PHẨM
        // =========================

        public string ProductName { get; set; }


        public string Description { get; set; }


        public string ImageURL { get; set; }





        // =========================
        // GIÁ
        // =========================

        public decimal PriceM { get; set; }


        public decimal PriceL { get; set; }





        // =========================
        // TRẠNG THÁI HIỂN THỊ
        // =========================


        // Sản phẩm nổi bật
        public bool IsFeatured { get; set; }



        // Sản phẩm mới
        public bool IsNew { get; set; }




        // Bán chạy
        public bool IsBestSeller { get; set; }




        // Đang hoạt động
        public bool Status { get; set; }





        // =========================
        // NGÀY TẠO
        // =========================

        public DateTime? CreatedDate { get; set; }



    }
}