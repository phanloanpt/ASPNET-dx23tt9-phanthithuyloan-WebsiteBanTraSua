using System;

namespace Model
{
    public class Topping
    {
        public int ToppingID { get; set; }

        public string ToppingName { get; set; }

        public decimal Price { get; set; }

        public string ImageURL { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}