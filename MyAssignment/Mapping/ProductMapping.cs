using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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