using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Image { get; set; }
        public float RateStar { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        [ForeignKey("category")]
        public int? IDCate { get; set; }
        public virtual Category category { get; set; }

    }
}
