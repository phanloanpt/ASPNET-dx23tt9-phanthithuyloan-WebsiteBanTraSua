using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL =
            new ProductDAL();

        // =========================
        // FRONTEND
        // =========================

        public List<Product> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        public List<Product> SearchProducts(
            string keyword)
        {
            return productDAL.SearchProducts(
                keyword);
        }

        public List<Product> GetFeaturedProducts()
        {
            return productDAL.GetFeaturedProducts();
        }

        public List<Product> GetNewProducts()
        {
            return productDAL.GetNewProducts();
        }

        public List<Product> GetBestSellerProducts()
        {
            return productDAL.GetBestSellerProducts();
        }

        public List<Product> GetProductsByCategory(
            int id)
        {
            return productDAL.GetProductsByCategory(
                id);
        }

        public Product GetProductByID(
            int id)
        {
            return productDAL.GetProductByID(
                id);
        }

        // =========================
        // ADMIN CRUD
        // =========================

        public List<Product> GetAllProductsAdmin()
        {
            return productDAL.GetAllProductsAdmin();
        }

        public Product GetProductByIDAdmin(
            int id)
        {
            return productDAL.GetProductByID(
                id);
        }

        public bool AddProduct(
            Product product)
        {
            return productDAL.InsertProduct(
                product);
        }

        public bool UpdateProduct(
            Product product)
        {
            return productDAL.UpdateProduct(
                product);
        }

        public bool DeleteProduct(
            int id)
        {
            return productDAL.DeleteProduct(
                id);
        }

        public bool RestoreProduct(
            int productID)
        {
            return productDAL.RestoreProduct(
                productID);
        }
    }
}