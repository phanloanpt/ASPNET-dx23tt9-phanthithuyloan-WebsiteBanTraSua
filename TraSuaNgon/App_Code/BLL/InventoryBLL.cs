using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class InventoryBLL
    {
        private InventoryDAL dal =
            new InventoryDAL();

        public List<Inventory> GetAll()
        {
            return dal.GetAll();
        }

        public Inventory GetByName(
            string name)
        {
            return dal.GetByName(name);
        }

        public void UpdateQuantity(
            int inventoryID,
            int quantity)
        {
            dal.UpdateQuantity(
                inventoryID,
                quantity);
        }

        public void Export(
            int inventoryID,
            int quantity)
        {
            dal.Export(
                inventoryID,
                quantity);
        }
    }
}