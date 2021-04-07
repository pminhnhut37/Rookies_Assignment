using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment.Shared.Product;
using Microsoft.AspNetCore.Mvc;
using MyAssignment.Respositories.ProductRespo;

namespace MyAssignment.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProductsController : ControllerBase
    {

        private IProduct _productRespo;

        public ProductsController(IProduct productRespository)
        {
            _productRespo = productRespository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRespone>> GetProduct(int idProduct)
        {
            var result = await _productRespo.GetProduct(idProduct);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRespone>>> GetProducts()
        {
            var result = await _productRespo.GetProducts();
            return Ok(result);
        }
    }
}
