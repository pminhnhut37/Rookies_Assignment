using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Shared.Product;

namespace MyAssignment.Respositories.ProductRespo
{
    public interface IProduct
    {
        Task<ProductRespone> GetProduct(int idProduct);

        Task<IEnumerable<ProductRespone>> GetProducts();
        Task<IEnumerable<ProductRespone>> GetProductsByCategory(int idcate);

        Task<ProductRespone> DeleteProduct(int IDProduct);

        Task<ProductRespone> UpdateProduct(int IDProduct, ProductRequest productRequest);
    }
}
