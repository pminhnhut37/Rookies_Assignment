using Assignment.Shared.Rating;
using AutoMapper;
using MyAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAssignment.Models;
using Microsoft.EntityFrameworkCore;


namespace MyAssignment.Respositories.RatingRespo
{
    public class RatingRespository : IRatingRespo
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;


        public RatingRespository(IMapper mapper, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _context = dbContext;

        }

        public async Task<IEnumerable<RatingVM>> GetRatingsByProductId(int id)
        {
            var ratings = await _context.Ratings
                .Include(p => p.Product)
                .Where(p => p.ProductID.Equals(id))
                .AsNoTracking()
                .ToListAsync();

            var result = _mapper.Map<IEnumerable<RatingVM>>(ratings);

            return result;
        }


        public async Task<RatingVM> Create(RatingRequest ratingRes)
        {
            var rate = _mapper.Map<Rating>(ratingRes);
            _context.Ratings.Add(rate);
            rate.DateRating = DateTime.Now;

            await _context.SaveChangesAsync();

            var productRated = await _context.Products.FindAsync(ratingRes.ProductID);
            var rateStar = await Task.FromResult(_context.Ratings
                .Where(rate => rate.ProductID.Equals(ratingRes.ProductID))
                .Select(rate => rate.Value)
                .Average());
            productRated.RateStar = (float)rateStar;
            await _context.SaveChangesAsync();

            var result = _mapper.Map<RatingVM>(rate);

            return result;
        }
    }
}
