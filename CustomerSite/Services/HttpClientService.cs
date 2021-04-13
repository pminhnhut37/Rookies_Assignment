using Assignment.Shared.Product;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerSite.ContranstEndpoints;

namespace CustomerSite.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _client;

        public HttpClientService(HttpClient client)
        {
            _client = client;
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
    }
}
