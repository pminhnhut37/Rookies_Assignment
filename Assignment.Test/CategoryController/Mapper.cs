using AutoMapper;
using Assignment.Shared.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAssignment.Models;

namespace Assignment.Test.CategoryController
{
    public static class Mapper
    {
        public static IMapper Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryVM, Category>().ReverseMap();
                cfg.CreateMap<CategoryCreateRequest, Category>().ReverseMap();

            });

            return config.CreateMapper();
        }
    }
}
