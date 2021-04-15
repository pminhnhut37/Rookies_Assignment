using Assignment.Shared.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAssignment.Respositories.RatingRespo
{
    public interface IRatingRespo
    {
        Task<IEnumerable<RatingVM>> GetRatingsByProductId(int id);
        Task<RatingVM> Create(RatingRequest ratingRes);
    }
}
