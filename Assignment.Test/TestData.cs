using Assignment.Shared.Product;
using Assignment.Shared.Category;
using MyAssignment.Models;
using System;


namespace Assignment.Test
{
    public static class TestData
    {
        public static ProductRequest NewProductRequest() => new ProductRequest
        {
            NameProduct = "Test ProductRequest Name",
            Price = 200,
            Image = null,
            ProductDescription = "Test ProductRequest Description"
        };

        public static Category NewCategory() => new Category
        {
            NameCate = "Test CategoryRequest Name"
        };

        public static Product NewProduct() => new Product
        {
            NameProduct = "Test Product Name",
            Price = 100,
            Image = "add.png",
            ProductDescription = "Test Product Description",
            RateStar = 0
        };

        public static CategoryCreateRequest NewCategoryRequest() => new CategoryCreateRequest
        {
            NameCate = "Test Category Request"
        };
    }
}
