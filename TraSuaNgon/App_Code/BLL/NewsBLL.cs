using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class NewsBLL
    {
        private NewsDAL dal = new NewsDAL();

        public List<News> GetAllNews()
        {
            return dal.GetAllNews();
        }
    }
}