using Assignment.Shared.Product;
using Assignment.Shared.Rating;
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
            var rate = await _client.GetRating(id);
            ViewBag.rate = rate;
            ViewBag.rateCount = rate.Count();
            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRespone>>> Categories(int? id)
        {
            if (id is not null)
            {
                var productsByCategory = await _client.GetProductByCategory(id.Value);
                switch(id.Value)
                {
                    case 1:
                        ViewBag.NameCate = "MEN";
                        break;
                    case 2:
                        ViewBag.NameCate = "WOMEN";
                        break;
                    case 3:
                        ViewBag.NameCate = "UNISEX";
                        break;

                };
                return View(productsByCategory);
            }

            var products = await _client.GetProducts();

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> PostReview(int rate, string comments, int productId)
        {
            var rating = new RatingRequest
            {

                Comment = comments,
                Value = rate,
                ProductID = productId
            };

            await _client.PostRating(rating);

            return RedirectToAction("Detail", new { id = productId });
        }
    }
}
