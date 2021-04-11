using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Shared.Product
{
    public class ProductRequest
    {
        public string NameProduct { get; set; }
        public float Price { get; set; }
        public string ProductDescription { get; set; }
        public string Image { get; set; }
        public int RateStar { get; set; }
    }
}
