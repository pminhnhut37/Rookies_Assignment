using Microsoft.AspNetCore.Mvc;
using MyAssignment.Respositories.RatingRespo;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment.Shared.Rating;
using Microsoft.AspNetCore.Authorization;

namespace MyAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingRespo _ratingRespo;

        public RatingsController(IRatingRespo ratingRespo)
        {
            _ratingRespo = ratingRespo;
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<ActionResult<RatingVM>> CreateRating(RatingRequest ratingRequest)
        {
            var result = await _ratingRespo.Create(ratingRequest);

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RatingVM>>> GetRatingsByProductID(int id)
        {
            var result = await _ratingRespo.GetRatingsByProductId(id);

            return Ok(result);
        }
    }
}
