using Assignment.Shared.Product;
using AutoMapper;
using MyAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Test.ProductController
{
    public static class Mapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductRequest, Product>().ReverseMap();
                cfg.CreateMap<ProductRespone, Product>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}
