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

        public bool InsertNews(News news)
        {
            return dal.InsertNews(news);
        }

        public News GetNewsByID(int id)
        {
            return dal.GetNewsByID(id);
        }

        public bool UpdateNews(News news)
        {
            return dal.UpdateNews(news);
        }

        public bool DeleteNews(int id)
        {
            return dal.DeleteNews(id);
        }
    }
}