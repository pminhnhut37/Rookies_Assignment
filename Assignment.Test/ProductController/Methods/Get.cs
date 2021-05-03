using Assignment.Shared.Product;
using Microsoft.AspNetCore.Mvc;
using MyAssignment.Controllers;
using MyAssignment.Respositories.ProductRespo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Assignment.Test.ProductController.Methods
{
    public class Get : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Get(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task GetAll_Success()
        {
            // Arrange

            var mapper = Mapper.Get();
            var dbContext = _fixture.Context;
            var storageService = Service.FileStorageSerive.IStorageService();

            var category = TestData.NewCategory();
            var product1 = TestData.NewProduct();
            var product2 = TestData.NewProduct();

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            await dbContext.Products.AddRangeAsync(product1, product2);
            product1.IDCate = category.IDCate;
            product2.IDCate = category.IDCate;
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRespository(mapper, dbContext, storageService);
            var productController = new ProductsController(productRepository);

            // Act
            var result = await productController.GetProducts(null);

            // Assert
            var getProductsResultType = Assert.IsType<ActionResult<IEnumerable<ProductRespone>>>(result);
            var getProductsResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotEmpty(getProductsResult.Value as IEnumerable<ProductRespone>);

        }

        [Fact]
        public async Task GetById_Success()
        {
            // Arrange
            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;
            var storageService = Service.FileStorageSerive.IStorageService();
            var category = TestData.NewCategory();
            var product1 = TestData.NewProduct();
            var product2 = TestData.NewProduct();

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            await dbContext.Products.AddRangeAsync(product1, product2);
            product1.IDCate = category.IDCate;
            product2.IDCate = category.IDCate;
            await dbContext.SaveChangesAsync();

            var productRepository = new ProductRespository(mapper, dbContext, storageService);

            var productController = new ProductsController(productRepository);

            // Act
            var result = await productController.GetProduct(product1.IDProduct);

            // Assert
            var productResult = Assert.IsType<OkObjectResult>(result.Result);
            var productValue = Assert.IsType<ProductRespone>(productResult.Value);

            Assert.Equal(product1.NameProduct, productValue.NameProduct);
            Assert.Equal(product1.Price, productValue.Price);
            Assert.Equal(product1.ProductDescription, productValue.ProductDescription);
            Assert.Equal(product1.Image, productValue.Image);
            Assert.Equal(product1.RateStar, productValue.RateStar);

            Assert.Equal(category.IDCate, productValue.IDCate);
        }
    }
}
