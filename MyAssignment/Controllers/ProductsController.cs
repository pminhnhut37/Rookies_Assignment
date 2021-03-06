using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment.Shared.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAssignment.Respositories.ProductRespo;

namespace MyAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private IProduct _productRespo;

        public ProductsController(IProduct productRespository)
        {
            _productRespo = productRespository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductRespone>> GetProduct(int id)
        {
            var result = await _productRespo.GetProduct(id);

            if (result is null)
            { return NotFound(); }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRespone>>> GetProducts(int? id)
        {
            if (id is not null)
            {
                var productsByCate = await _productRespo.GetProductsByCategory(id.Value);
                return Ok(productsByCate);
            }

            var products = await _productRespo.GetProducts();
            return Ok(products);
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public async Task<ActionResult<ProductRespone>> RemoveProduct(int id)
        {
            var productRes = await _productRespo.DeleteProduct(id);

            return Ok(productRes);
        }

        [HttpPut("{id}")]
        [Authorize("Bearer")]
        public async Task<ActionResult<ProductRespone>> UpdateProduct(int id,[FromForm] ProductRequest productReq)
        {
            var productRes = await _productRespo.UpdateProduct(id, productReq);

            return Ok(productRes);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult<ProductRespone>> CreateProduct([FromForm] ProductRequest productRequest)
        {
            var product = await _productRespo.CreateProduct(productRequest);
            
            return Created("/Products", productRequest);
        }
    }
}
