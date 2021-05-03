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
    public class Post : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public Post(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task Create_Success()
        {
            // Arrange
            var mapper = Mapper.Get();

            var dbContext = _fixture.Context;

            var categoryRequest = TestData.NewCategoryRequest();

            var categoryRepository = new CategoryRespository(mapper, dbContext);
            var catgoriesController = new CategoriesController(categoryRepository);

            // Act
            var result = await catgoriesController.Create(categoryRequest);

            // Assert
            var createdCategoryResult = Assert.IsType<CreatedResult>(result.Result);
            var resultValue = Assert.IsType<CategoryVM>(createdCategoryResult.Value);

            Assert.Equal(categoryRequest.NameCate, resultValue.NameCate);
        }
    }
}
