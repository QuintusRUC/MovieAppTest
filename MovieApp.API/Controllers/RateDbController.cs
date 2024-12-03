using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer;
using System.Threading.Tasks;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateDbController : ControllerBase
    {
        private readonly RateDbBusinessService _rateDbBusinessService;

        public RateDbController(RateDbBusinessService rateDbBusinessService)
        {
            _rateDbBusinessService = rateDbBusinessService;
        }

        // API-endpoint til at rate en film
        [HttpPost]
        public async Task<IActionResult> RateMovie([FromQuery] int userId, [FromQuery] string movieId, [FromQuery] int rating)
        {
            if (rating < 1 || rating > 10)
            {
                return BadRequest("Rating must be between 1 and 10.");
            }

            await _rateDbBusinessService.RateMovieAsync(userId, movieId, rating);
            return Ok("Rating updated successfully.");
        }
    }
}
