﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment.Shared.Product;
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
        public async Task<ActionResult<ProductRespone>> GetProduct(int idProduct)
        {
            var result = await _productRespo.GetProduct(idProduct);

            if (result is null)
            { return NotFound(); }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRespone>>> GetProducts(int? idCate)
        {
            if (idCate is not null)
            {
                var productsByCate = await _productRespo.GetProductsByCategory(idCate.Value);
                return Ok(productsByCate);
            }

            var products = await _productRespo.GetProducts();
            return Ok(products);
        }

    }
}