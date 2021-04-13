using Assignment.Shared.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Services
{
    public interface IHttpClientService
    {

        Task<IEnumerable<ProductRespone>> GetProducts();
        Task<ProductRespone> GetProduct(int id);
        Task<IEnumerable<ProductRespone>> GetProductByCategory(int id);

    }
}
