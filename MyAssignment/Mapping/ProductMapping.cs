using AutoMapper;
using MyAssignment.Models;
using Assignment.Shared.Product;

namespace MyAssignment.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<ProductRequest, Product>().ReverseMap();

            CreateMap<ProductRespone, Product>().ReverseMap();
        }

    }
}