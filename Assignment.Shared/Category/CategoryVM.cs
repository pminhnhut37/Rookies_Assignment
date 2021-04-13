using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Shared.Category
{
    public class CategoryVM
    {
        public int IDCate { get; set; }
        public string NameCate { get; set; }
        public virtual List<Product.ProductRespone> Products { get; set; }
    }
}