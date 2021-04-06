using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MyAssignment.Models
{
    public class Product
    {
        [Key]
        public int IDProduct { get; set; }

        [Required]
        public string NameProduct { get; set; }
        public float Price { get; set; }
        public string ProductDescription { get; set; }


        public int? IDCate { get; set; }
        public Category category { get; set; }

    }
}
