using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class InventoryBLL
    {
        private InventoryDAL dal = new InventoryDAL();


        public List<Inventory> GetAll()
        {
            return dal.GetAll();
        }
    }
}