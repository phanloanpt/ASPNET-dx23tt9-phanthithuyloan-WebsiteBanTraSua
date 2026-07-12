using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();

        // Lấy tất cả sản phẩm
        public List<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        // Tìm kiếm sản phẩm theo từ khóa
        public List<Product> SearchProducts(string keyword)
        {
            return productDAL.SearchProducts(keyword);
        }

        // Sản phẩm nổi bật
        public List<Product> GetFeaturedProducts()
        {
            return productDAL.GetFeaturedProducts();
        }

        // Sản phẩm mới
        public List<Product> GetNewProducts()
        {
            return productDAL.GetNewProducts();
        }

        // Sản phẩm bán chạy
        public List<Product> GetBestSellerProducts()
        {
            return productDAL.GetBestSellerProducts();
        }

        // Lấy sản phẩm theo danh mục
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return productDAL.GetProductsByCategory(categoryId);
        }
        // Lấy sản phẩm theo id
        public Product GetProductByID(int productId)
        {
            return productDAL.GetProductByID(productId);
        }
    }
}