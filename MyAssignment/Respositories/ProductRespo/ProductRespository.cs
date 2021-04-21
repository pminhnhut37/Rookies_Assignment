using AutoMapper;
using MyAssignment.Data;
using Assignment.Shared.Product;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyAssignment.Models;
using System.Net.Http.Headers;
using System.IO;
using MyAssignment.Services;
using Microsoft.AspNetCore.Http;

namespace MyAssignment.Respositories.ProductRespo
{
    public class ProductRespository : IProduct
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private IStorageService _storageService;

        public ProductRespository(IMapper mapper, ApplicationDbContext dbContext, IStorageService storageService)
        {
            _mapper = mapper;
            _context = dbContext;
            _storageService = storageService;
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

        public async Task<ProductRespone> DeleteProduct(int IDProduct)
        {
            var product = await _context.Products.FindAsync(IDProduct);

            var productRes = _mapper.Map<ProductRespone>(product);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return productRes;
        }

        public async Task<ProductRespone> UpdateProduct(int IDProduct, ProductRequest productRequest)
        {
            var existProduct = await _context.Products.FindAsync(IDProduct);

            _context.Entry(existProduct).CurrentValues.SetValues(productRequest);
            existProduct.UpdateDate = DateTime.Now.Date;
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(existProduct);

            return productRes;
        }

        public async Task<ProductRespone> CreateProduct(ProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            product.Image = await SaveFile(productRequest.Image);

            product.CreateDate = DateTime.Now;
            product.UpdateDate = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(product);
            productRes.Image = _storageService.GetFileUrl(productRes.Image);
            return productRes;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
           
            await _storageService.SaveFileAsync(file.OpenReadStream(), originalFileName);

            return originalFileName;
        }
    }
}
