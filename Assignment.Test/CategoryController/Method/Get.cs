using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MyAssignment.Respositories.CategoryRespo;
using MyAssignment.Controllers;
using Microsoft.AspNetCore.Mvc;
using Assignment.Shared.Category;

namespace Assignment.Test.CategoryController.Method
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

            var category1 = TestData.NewCategory();
            var category2 = TestData.NewCategory();
            var category3 = TestData.NewCategory();

            await dbContext.AddRangeAsync(category1, category2, category3);
            await dbContext.SaveChangesAsync();

            var categoryRepository = new CategoryRespository(mapper, dbContext);
            var catgoriesController = new CategoriesController(categoryRepository);

            // Act
            var result = await catgoriesController.GetCategories();

            // Assert
            var getCategoriesResultType = Assert.IsType<ActionResult<IEnumerable<CategoryVM>>>(result);
            var getCategoriesResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.NotEmpty(getCategoriesResult.Value as IEnumerable<CategoryVM>);
        }
    }
}
