using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class NewsDAL
    {
        private string connectionString =
            ConfigurationManager
            .ConnectionStrings["TraSuaNgonConnection"]
            .ConnectionString;


        public List<Model.News> GetAllNews()
        {
            List<Model.News> list =
                new List<Model.News>();

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query =
                    "SELECT * FROM News ORDER BY CreatedDate DESC";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    Model.News news =
                        new Model.News();

                    news.NewsID =
                        Convert.ToInt32(reader["NewsID"]);

                    news.Title =
                        reader["Title"].ToString();

                    news.Summary =
                        reader["Summary"].ToString();

                    news.Content =
                        reader["Content"].ToString();

                    news.ImageURL =
                        reader["ImageURL"].ToString();

                    news.Author =
                        reader["Author"].ToString();

                    news.IsFeatured =
                        Convert.ToBoolean(reader["IsFeatured"]);

                    news.Status =
                        Convert.ToBoolean(reader["Status"]);

                    news.CreatedDate =
                        Convert.ToDateTime(reader["CreatedDate"]);

                    list.Add(news);
                }
            }

            return list;
        }


        public bool InsertNews(Model.News news)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string sql = @"
                INSERT INTO News
                (
                    Title,
                    Summary,
                    Content,
                    ImageURL,
                    Author,
                    IsFeatured,
                    Status,
                    CreatedDate
                )
                VALUES
                (
                    @Title,
                    @Summary,
                    @Content,
                    @ImageURL,
                    @Author,
                    @IsFeatured,
                    @Status,
                    @CreatedDate
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Title", news.Title);
                cmd.Parameters.AddWithValue("@Summary", news.Summary);
                cmd.Parameters.AddWithValue("@Content", news.Content);
                cmd.Parameters.AddWithValue("@ImageURL", news.ImageURL);
                cmd.Parameters.AddWithValue("@Author", news.Author);
                cmd.Parameters.AddWithValue("@IsFeatured", news.IsFeatured);
                cmd.Parameters.AddWithValue("@Status", news.Status);
                cmd.Parameters.AddWithValue("@CreatedDate", news.CreatedDate);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public Model.News GetNewsByID(int id)
        {
            Model.News news = null;

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string sql =
                    "SELECT * FROM News WHERE NewsID=@NewsID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@NewsID",
                    id);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    news =
                        new Model.News();

                    news.NewsID =
                        Convert.ToInt32(reader["NewsID"]);

                    news.Title =
                        reader["Title"].ToString();

                    news.Summary =
                        reader["Summary"].ToString();

                    news.Content =
                        reader["Content"].ToString();

                    news.ImageURL =
                        reader["ImageURL"].ToString();

                    news.Author =
                        reader["Author"].ToString();

                    news.IsFeatured =
                        Convert.ToBoolean(reader["IsFeatured"]);

                    news.Status =
                        Convert.ToBoolean(reader["Status"]);

                    news.CreatedDate =
                        Convert.ToDateTime(reader["CreatedDate"]);
                }
            }

            return news;
        }


        public bool UpdateNews(Model.News news)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string sql = @"
                UPDATE News
                SET
                    Title=@Title,
                    Summary=@Summary,
                    Content=@Content,
                    ImageURL=@ImageURL,
                    Author=@Author,
                    IsFeatured=@IsFeatured,
                    Status=@Status
                WHERE NewsID=@NewsID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@NewsID", news.NewsID);
                cmd.Parameters.AddWithValue("@Title", news.Title);
                cmd.Parameters.AddWithValue("@Summary", news.Summary);
                cmd.Parameters.AddWithValue("@Content", news.Content);
                cmd.Parameters.AddWithValue("@ImageURL", news.ImageURL);
                cmd.Parameters.AddWithValue("@Author", news.Author);
                cmd.Parameters.AddWithValue("@IsFeatured", news.IsFeatured);
                cmd.Parameters.AddWithValue("@Status", news.Status);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool DeleteNews(int id)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string sql =
                    "DELETE FROM News WHERE NewsID=@NewsID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@NewsID",
                    id);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}