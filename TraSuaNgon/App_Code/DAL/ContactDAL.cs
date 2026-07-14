using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class ContactDAL
    {
        private string connectionString =
            ConfigurationManager
            .ConnectionStrings["TraSuaNgonConnection"]
            .ConnectionString;

        public List<Model.ContactMessage> GetAllMessages()
        {
            List<Model.ContactMessage> list =
                new List<Model.ContactMessage>();

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string sql =
                    @"SELECT *
                      FROM ContactMessages
                      ORDER BY CreatedDate DESC";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    Model.ContactMessage message =
                        new Model.ContactMessage();

                    message.MessageID =
                        Convert.ToInt32(
                            reader["MessageID"]);

                    message.FullName =
                        reader["FullName"].ToString();

                    message.Email =
                        reader["Email"].ToString();

                    message.Phone =
                        reader["Phone"].ToString();

                    message.Subject =
                        reader["Subject"].ToString();

                    message.Message =
                        reader["Message"].ToString();

                    message.CreatedDate =
                        Convert.ToDateTime(
                            reader["CreatedDate"]);

                    message.IsRead =
                        Convert.ToBoolean(
                            reader["IsRead"]);

                    list.Add(message);
                }
            }

            return list;
        }

        public bool InsertMessage(
            Model.ContactMessage message)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string sql = @"
                INSERT INTO ContactMessages
                (
                    FullName,
                    Email,
                    Phone,
                    Subject,
                    Message,
                    CreatedDate,
                    IsRead
                )
                VALUES
                (
                    @FullName,
                    @Email,
                    @Phone,
                    @Subject,
                    @Message,
                    @CreatedDate,
                    @IsRead
                )";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@FullName",
                    message.FullName);

                cmd.Parameters.AddWithValue(
                    "@Email",
                    message.Email);

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    message.Phone);

                cmd.Parameters.AddWithValue(
                    "@Subject",
                    message.Subject);

                cmd.Parameters.AddWithValue(
                    "@Message",
                    message.Message);

                cmd.Parameters.AddWithValue(
                    "@CreatedDate",
                    message.CreatedDate);

                cmd.Parameters.AddWithValue(
                    "@IsRead",
                    message.IsRead);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public Model.ContactMessage GetMessageByID(
            int id)
        {
            Model.ContactMessage message =
                null;

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string sql =
                    @"SELECT *
                      FROM ContactMessages
                      WHERE MessageID=@MessageID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@MessageID",
                    id);

                conn.Open();

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    message =
                        new Model.ContactMessage();

                    message.MessageID =
                        Convert.ToInt32(
                            reader["MessageID"]);

                    message.FullName =
                        reader["FullName"].ToString();

                    message.Email =
                        reader["Email"].ToString();

                    message.Phone =
                        reader["Phone"].ToString();

                    message.Subject =
                        reader["Subject"].ToString();

                    message.Message =
                        reader["Message"].ToString();

                    message.CreatedDate =
                        Convert.ToDateTime(
                            reader["CreatedDate"]);

                    message.IsRead =
                        Convert.ToBoolean(
                            reader["IsRead"]);
                }
            }

            return message;
        }

        public bool MarkAsRead(int id)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string sql =
                    @"UPDATE ContactMessages
                      SET IsRead=1
                      WHERE MessageID=@MessageID";

                SqlCommand cmd =
                    new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue(
                    "@MessageID",
                    id);

                conn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}