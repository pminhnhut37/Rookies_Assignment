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

            await dbContext.AddRangeAsync(category);
            await dbContext.SaveChangesAsync();

            var categoryRepository = new CategoryRespository(mapper, dbContext);
            var catgoriesController = new CategoriesController(categoryRepository);

            // Act
            var result = await catgoriesController.Delete(category.IDCate);

            // Assert
            var createdCategoryResult = Assert.IsType<OkObjectResult>(result.Result);
            var resultValue = Assert.IsType<CategoryVM>(createdCategoryResult.Value);

            Assert.Equal(category.NameCate, resultValue.NameCate);

        }
    }
}
