using System;

namespace Assignment.Shared.Rating
{
    public class RatingVM
    {
        public int IdRating { get; set; }

        public int Value { get; set; }
        public string Comment { get; set; }

        public int ProductID { get; set; }

        public DateTime DateRating { get; set; }
    }
}
