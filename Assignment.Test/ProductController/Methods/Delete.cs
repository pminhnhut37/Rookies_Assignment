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
    public class Delete : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Delete(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task Delete_Success()
        {
            // Arrange

            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var category = TestData.NewCategory();
            await dbContext.Categories.AddRangeAsync(category);
            await dbContext.SaveChangesAsync();

            var product = TestData.NewProduct();
            product.IDCate = category.IDCate;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productRepo = new ProductRespository(mapper, dbContext);
            var productController = new ProductsController(productRepo);

            // Act
            var result = await productController.RemoveProduct(product.IDProduct);

            // Assert
            var deletedResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedResultValue = Assert.IsType<ProductRespone>(deletedResult.Value);

            Assert.Equal(product.NameProduct, deletedResultValue.NameProduct);
            Assert.Equal(product.Price, deletedResultValue.Price);
            Assert.Equal(product.ProductDescription, deletedResultValue.ProductDescription);
            Assert.Equal(product.Image, deletedResultValue.Image);
            Assert.Equal(product.RateStar, deletedResultValue.RateStar);
            Assert.Equal(category.IDCate, deletedResultValue.IDCate);

            
        }
    }
}
