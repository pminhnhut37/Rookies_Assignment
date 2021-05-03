using Assignment.Shared.Product;
using Microsoft.AspNetCore.Mvc;
using MyAssignment.Controllers;
using MyAssignment.Respositories.ProductRespo;
using MyAssignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assignment.Test.ProductController.Methods
{
    public class Post : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Post(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }
        [Fact]
        public async Task Post_Success()
        {

            var mapper = Mapper.Get();
            var dbContext = _fixture.Context;
            var storageService = Service.FileStorageSerive.IStorageService();

            var category = TestData.NewCategory();

            await dbContext.Categories.AddRangeAsync(category);
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRespository(mapper, dbContext, storageService);

            var productRequest = TestData.NewProductRequest();
            productRequest.IDCate = category.IDCate;

            // Act
            var productController = new ProductsController(productRepository);
            var result = await productController.CreateProduct(productRequest);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result.Result);
            var returnValue = Assert.IsType<ProductRespone>(createdResult.Value);

            Assert.Equal(productRequest.NameProduct, returnValue.NameProduct);
            Assert.Equal(productRequest.Price, returnValue.Price);
            Assert.Equal(productRequest.ProductDescription, returnValue.ProductDescription);
            //Assert.Equal(productRequest.Image, returnValue.Image);
            Assert.Equal(0, returnValue.RateStar);
            Assert.Equal(category.IDCate, returnValue.IDCate);

        }
    }
}
