using System;
using System.ComponentModel.DataAnnotations;

namespace MyAssignment.Models
{
    public class Rating
    {   
        [Key]
        public int IdRating { get; set; }

        public int Value { get; set; }
        public string Comment { get; set; }
        public int ProductID { get; set; }

        public DateTime DateRating { get; set; }

        public virtual Product Product { get; set; }
    }
}
