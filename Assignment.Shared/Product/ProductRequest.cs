using Microsoft.AspNetCore.Http;

namespace Assignment.Shared.Product
{
    public class ProductRequest
    {
        public string NameProduct { get; set; }
        public float Price { get; set; }
        public string ProductDescription { get; set; }
        public IFormFile Image { get; set; }
        public int RateStar { get; set; }
    }
}
