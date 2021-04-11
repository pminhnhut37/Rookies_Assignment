using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Shared.Category;
using MyAssignment.Models;
using AutoMapper;

namespace MyAssignment.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryVM, Category>().ReverseMap();

            CreateMap<CategoryCreateRequest, Category>().ReverseMap();
        }
    }
}
