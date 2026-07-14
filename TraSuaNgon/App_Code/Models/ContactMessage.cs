using System;

namespace Model
{
    public class ContactMessage
    {
        public int MessageID { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsRead { get; set; }
    }
}