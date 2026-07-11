using System;

namespace Model
{
    public class News
    {
        public int NewsID { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public string ImageURL { get; set; }

        public string Author { get; set; }

        public bool IsFeatured { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}