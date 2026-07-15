using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class ReportBLL
    {
        private ReportDAL dal =
            new ReportDAL();

        public ReportModel GetDashboard()
        {
            return dal.GetDashboard();
        }

        public List<BestSellerModel> GetBestSeller()
        {
            return dal.GetBestSeller();
        }

        public List<LowStockModel> GetLowStock()
        {
            return dal.GetLowStock();
        }
    }
}