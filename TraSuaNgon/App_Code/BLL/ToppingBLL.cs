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
    }
}