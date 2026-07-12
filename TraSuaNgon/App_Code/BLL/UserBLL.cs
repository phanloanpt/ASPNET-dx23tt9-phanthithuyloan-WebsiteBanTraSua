using System.Collections.Generic;
using DAL;
using Model;


namespace BLL
{
    public class UserBLL
    {


        private UserDAL userDAL =
            new UserDAL();





        // ==========================
        // ĐĂNG KÝ
        // ==========================

        public bool Register(User user)
        {

            return userDAL.Register(user);

        }








        // ==========================
        // ĐĂNG NHẬP
        // ==========================

        public User Login(
            string email,
            string password)
        {

            return userDAL.Login(
                email,
                password);

        }








        // ==========================
        // ADMIN:
        // LẤY DANH SÁCH USER
        // ==========================

        public List<User> GetAllUsers()
        {

            return userDAL.GetAllUsers();

        }








        // ==========================
        // ADMIN:
        // KHÓA / MỞ KHÓA USER
        // ==========================

        public bool UpdateStatus(
            int userID,
            bool status)
        {

            return userDAL.UpdateStatus(
                userID,
                status);

        }



    }
}