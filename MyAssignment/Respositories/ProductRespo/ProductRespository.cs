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
            if (product is not null)
            {
                product.Image = _storageService.GetFileUrl(product.Image);
            }
            var result = _mapper.Map<ProductRespone>(product);
            return result;
        }

        public async Task<IEnumerable<ProductRespone>> GetProducts()
        {
            var listProduct = await _context.Products.AsNoTracking().ToListAsync();
            foreach (var item in listProduct)
            {
                item.Image = _storageService.GetFileUrl(item.Image);
            }

            var result = _mapper.Map<IEnumerable<ProductRespone>>(listProduct);

            return result;
        }

        public async Task<IEnumerable<ProductRespone>> GetProductsByCategory(int idcate)
        {
            var products = await _context.Products.Where(product => product.IDCate.Equals(idcate)).AsNoTracking().ToListAsync();
            foreach (var item in products)
            {
                item.Image = _storageService.GetFileUrl(item.Image);
            }

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
            //Can not map (string) Image with (IFormFile) Image
            var existProduct = await _context.Products.FindAsync(IDProduct);
            _context.Entry(existProduct).State = EntityState.Modified;
            existProduct.NameProduct = productRequest.NameProduct;
            existProduct.ProductDescription = productRequest.ProductDescription;
            existProduct.Price = productRequest.Price;

            existProduct.Image = productRequest.Image.FileName;
            existProduct.IDCate = productRequest.IDCate;
            existProduct.UpdateDate = DateTime.Now.Date;
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductRespone>(existProduct);

            return productRes;
        }

        public async Task<ProductRespone> CreateProduct(ProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            if (productRequest.Image is null)
            {
                product.Image = "add.png";
            }
            else
            {
                product.Image = await SaveFile(productRequest.Image);

            }

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
            //var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), originalFileName);

            return originalFileName;
        }
    }
}
