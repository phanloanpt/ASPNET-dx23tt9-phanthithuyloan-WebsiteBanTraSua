using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class ToppingBLL
    {
        private ToppingDAL toppingDAL =
            new ToppingDAL();

        // Lấy tất cả topping
        public List<Topping> GetAllToppings()
        {
            return toppingDAL.GetAllToppings();
        }

        // Lấy topping theo ID
        public Topping GetToppingByID(int id)
        {
            return toppingDAL.GetToppingByID(id);
        }

        // Thêm topping
        public bool InsertTopping(Topping topping)
        {
            return toppingDAL.InsertTopping(topping);
        }

        // Cập nhật topping
        public bool UpdateTopping(Topping topping)
        {
            return toppingDAL.UpdateTopping(topping);
        }

        // Xóa topping
        public bool DeleteTopping(int id)
        {
            return toppingDAL.DeleteTopping(id);
        }
    }
}