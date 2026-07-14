using DAL;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class ContactBLL
    {
        private ContactDAL dal =
            new ContactDAL();

        public List<ContactMessage> GetAllMessages()
        {
            return dal.GetAllMessages();
        }

        public bool InsertMessage(
            ContactMessage message)
        {
            return dal.InsertMessage(
                message);
        }

        public ContactMessage GetMessageByID(
            int id)
        {
            return dal.GetMessageByID(
                id);
        }

        public bool MarkAsRead(int id)
        {
            return dal.MarkAsRead(
                id);
        }
    }
}