using AutoMapper;
using Assignment.Shared.Rating;
using MyAssignment.Models;

namespace MyAssignment.Mapping
{
    public class RatingMapping : Profile
    {
        public RatingMapping()
        {
            CreateMap<RatingVM, Rating>().ReverseMap();

            CreateMap<RatingRequest, Rating>().ReverseMap();
        }
    }
}
