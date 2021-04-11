using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Shared.Category
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product.ProductRespone> Products { get; set; }
    }
}
