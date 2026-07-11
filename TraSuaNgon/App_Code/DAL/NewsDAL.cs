using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class NewsDAL
    {
        private string connectionString =
            ConfigurationManager.ConnectionStrings["TraSuaNgonConnection"].ConnectionString;

        public List<News> GetAllNews()
        {
            List<News> list = new List<News>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM News ORDER BY CreatedDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    News news = new News();

                    news.NewsID = Convert.ToInt32(reader["NewsID"]);
                    news.Title = reader["Title"].ToString();
                    news.Summary = reader["Summary"].ToString();
                    news.Content = reader["Content"].ToString();
                    news.ImageURL = reader["ImageURL"].ToString();
                    news.Author = reader["Author"].ToString();
                    news.IsFeatured = Convert.ToBoolean(reader["IsFeatured"]);
                    news.Status = Convert.ToBoolean(reader["Status"]);
                    news.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);

                    list.Add(news);
                }
            }

            return list;
        }
    }
}