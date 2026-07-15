using DAL;
using Model;

namespace BLL
{
    public class InventoryLogBLL
    {
        private InventoryLogDAL dal =
            new InventoryLogDAL();


        public void Insert(
            InventoryLog log)
        {
            dal.Insert(log);
        }
    }
}