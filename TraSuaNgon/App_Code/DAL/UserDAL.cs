using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;


namespace DAL
{
    public class UserDAL
    {


        // =====================================
        // ĐĂNG KÝ USER
        // CUSTOMER MẶC ĐỊNH
        // =====================================

        public bool Register(User user)
        {

            using (SqlConnection conn = Database.GetConnection())
            {


                string sql = @"
                INSERT INTO Users
                (
                    FullName,
                    Email,
                    PasswordHash,
                    Phone,
                    Address,
                    Role,
                    Status,
                    CreatedDate
                )
                VALUES
                (
                    @FullName,
                    @Email,
                    @PasswordHash,
                    @Phone,
                    @Address,
                    @Role,
                    @Status,
                    @CreatedDate
                )";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@FullName",
                    user.FullName);



                cmd.Parameters.AddWithValue(
                    "@Email",
                    user.Email);



                cmd.Parameters.AddWithValue(
                    "@PasswordHash",
                    user.PasswordHash);



                cmd.Parameters.AddWithValue(
                    "@Phone",
                    user.Phone);



                cmd.Parameters.AddWithValue(
                    "@Address",
                    user.Address);



                cmd.Parameters.AddWithValue(
                    "@Role",
                    user.Role);



                cmd.Parameters.AddWithValue(
                    "@Status",
                    user.Status);



                cmd.Parameters.AddWithValue(
                    "@CreatedDate",
                    user.CreatedDate);



                conn.Open();



                return cmd.ExecuteNonQuery() > 0;


            }

        }








        // =====================================
        // LOGIN
        // =====================================

        public User Login(
            string email,
            string password)
        {


            using (SqlConnection conn =
                Database.GetConnection())
            {


                string sql = @"
                SELECT *
                FROM Users
                WHERE Email=@Email
                AND PasswordHash=@Password";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@Email",
                    email);



                cmd.Parameters.AddWithValue(
                    "@Password",
                    password);



                conn.Open();



                SqlDataReader reader =
                    cmd.ExecuteReader();




                if (reader.Read())
                {


                    User user =
                        new User();



                    user.UserID =
                        Convert.ToInt32(
                            reader["UserID"]);



                    user.FullName =
                        reader["FullName"].ToString();



                    user.Email =
                        reader["Email"].ToString();



                    user.Phone =
                        reader["Phone"].ToString();



                    user.Address =
                        reader["Address"].ToString();



                    user.Role =
                        reader["Role"].ToString();



                    user.Status =
                        Convert.ToBoolean(
                            reader["Status"]);



                    user.CreatedDate =
                        Convert.ToDateTime(
                            reader["CreatedDate"]);



                    return user;


                }



            }



            return null;


        }









        // =====================================
        // ADMIN:
        // LẤY DANH SÁCH USER
        // =====================================

        public List<User> GetAllUsers()
        {


            List<User> list =
                new List<User>();



            using (SqlConnection conn =
                Database.GetConnection())
            {


                string sql = @"
                SELECT *
                FROM Users
                ORDER BY UserID DESC";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                conn.Open();



                SqlDataReader reader =
                    cmd.ExecuteReader();




                while (reader.Read())
                {


                    User user =
                        new User();



                    user.UserID =
                        Convert.ToInt32(
                            reader["UserID"]);



                    user.FullName =
                        reader["FullName"].ToString();



                    user.Email =
                        reader["Email"].ToString();



                    user.Phone =
                        reader["Phone"].ToString();



                    user.Address =
                        reader["Address"].ToString();



                    user.Role =
                        reader["Role"].ToString();



                    user.Status =
                        Convert.ToBoolean(
                            reader["Status"]);



                    user.CreatedDate =
                        Convert.ToDateTime(
                            reader["CreatedDate"]);



                    list.Add(user);


                }


            }



            return list;


        }









        // =====================================
        // ADMIN:
        // KHÓA / MỞ KHÓA USER
        // =====================================

        public bool UpdateStatus(
            int userID,
            bool status)
        {


            using (SqlConnection conn =
                Database.GetConnection())
            {


                string sql = @"
                UPDATE Users
                SET Status=@Status
                WHERE UserID=@UserID";



                SqlCommand cmd =
                    new SqlCommand(sql, conn);



                cmd.Parameters.AddWithValue(
                    "@Status",
                    status);



                cmd.Parameters.AddWithValue(
                    "@UserID",
                    userID);



                conn.Open();



                return cmd.ExecuteNonQuery() > 0;


            }


        }



    }
}