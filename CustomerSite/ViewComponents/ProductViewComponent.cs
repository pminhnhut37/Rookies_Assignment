using Assignment.Shared.Product;
using CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerSite.ViewComponents
{
    [ViewComponent(Name = "Product")]
    public class ProductViewComponent : ViewComponent
    {
        private IHttpClientService _client;

        public ProductViewComponent(IHttpClientService client)
        {
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(ProductRespone products)
        {
            return await Task.FromResult(View("Default", products));
        }
    }
}
