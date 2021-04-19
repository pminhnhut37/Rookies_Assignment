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
            Image = "Test ProductRequest Image",
            ProductDescription = "Test ProductRequest Description",
            RateStar = 1
        };

        public static Category NewCategory() => new Category
        {
            NameCate = "Test CategoryRequest Name"
        };

        public static Product NewProduct() => new Product
        {
            NameProduct = "Test Product Name",
            Price = 100,
            Image = "Test Product Image",
            ProductDescription = "Test Product Description",
            RateStar = 1
        };

        public static CategoryCreateRequest NewCategoryRequest() => new CategoryCreateRequest
        {
            Name = "Test Category Request"
        };
    }
}
