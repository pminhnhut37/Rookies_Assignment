using Assignment.Shared.Product;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerSite.ContranstEndpoints;
using Assignment.Shared.Rating;
using Newtonsoft.Json;
using System.Text;

namespace CustomerSite.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _client;
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(HttpClient client, IHttpClientFactory httpClientFactory)
        {
            _client = client;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ProductRespone>> GetProducts()
        {
            var products = await _client.GetAsync(Endpoints.Product);
            products.EnsureSuccessStatusCode();

            var result = await products.Content.ReadAsAsync<IEnumerable<ProductRespone>>();

            return result;
        }

        public async Task<IEnumerable<ProductRespone>> GetProductByCategory(int id)
        {
            var products = await _client.GetAsync($"{Endpoints.Product}/?id={id}");
            products.EnsureSuccessStatusCode();

            var result = await products.Content.ReadAsAsync<IEnumerable<ProductRespone>>();

            return result;
        }

        public async Task<ProductRespone> GetProduct(int id)
        {
            var product = await _client.GetAsync(Endpoints.ProductById(id));
            product.EnsureSuccessStatusCode();
            var result = await product.Content.ReadAsAsync<ProductRespone>();

            return result;
        }

        public async Task<IEnumerable<RatingVM>> GetRating(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:5001/Ratings/" + id);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<IEnumerable<RatingVM>>();
        }

        public async Task<RatingRequest> PostRating(RatingRequest ratingRequest)
        {
            var client = _httpClientFactory.CreateClient();
            //var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var json = JsonConvert.SerializeObject(ratingRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:5001/Ratings", data);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<RatingRequest>();
        }
    }
}
