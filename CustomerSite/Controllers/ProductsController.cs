using Assignment.Shared.Product;
using CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class ProductsController : Controller
    {
        private IHttpClientService _client;

        public ProductsController(IHttpClientService client)
        {
            _client = client;
        }

        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<ProductRespone>> Detail(int id)
        {
            var product = await _client.GetProduct(id);

            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRespone>>> Categories(int? id)
        {
            if (id is not null)
            {
                var productsByCategory = await _client.GetProductByCategory(id.Value);

                return View(productsByCategory);
            }

            var products = await _client.GetProducts();

            return View(products);
        }
    }
}
