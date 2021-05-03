using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MyAssignment.Respositories.CategoryRespo;
using Assignment.Shared.Category;
using MyAssignment.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Test.CategoryController.Method
{
    public class Update : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Update(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task Update_Success()
        {
            // Arrange
            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var existCate = TestData.NewCategory();
            await dbContext.AddAsync(existCate);
            await dbContext.SaveChangesAsync();

            var newCategoryRequest = TestData.NewCategoryRequest();

            var categoryRepository = new CategoryRespository(mapper, dbContext);
            var catgoriesController = new CategoriesController(categoryRepository);

            // Act
            var result = await catgoriesController.Update(existCate.IDCate, newCategoryRequest);

            // Assert
            var createdCategoryResult = Assert.IsType<OkObjectResult>(result.Result);
            var resultValue = Assert.IsType<CategoryVM>(createdCategoryResult.Value);

            Assert.Equal(existCate.NameCate, resultValue.NameCate);

            Assert.Equal(existCate.NameCate, newCategoryRequest.NameCate);
        }
    }
}
