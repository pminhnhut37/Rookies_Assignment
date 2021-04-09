using AutoMapper;
using MyAssignment.Data;
using Assignment.Shared.Product;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MyAssignment.Respositories.ProductRespo
{
    public class ProductRespository : IProduct
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public ProductRespository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;
        }

        public async Task<ProductRespone> GetProduct(int idProduct)
        {
            var product = await _context.Products.FindAsync(idProduct);

            var result = _mapper.Map<ProductRespone>(product);
            return result;
        }

        public async Task<IEnumerable<ProductRespone>> GetProducts()
        {
            var listProduct = await _context.Products.AsNoTracking().ToListAsync();

            var result = _mapper.Map<IEnumerable<ProductRespone>>(listProduct);

            return result;
        }

        public async Task<IEnumerable<ProductRespone>> GetProductsByCategory(int idcate)
        {
            var products = await _context.Products.Where(product => product.IDCate.Equals(idcate)).AsNoTracking().ToListAsync();

            var result = _mapper.Map<IEnumerable<ProductRespone>>(products);

            return result;
        }
    }
}
