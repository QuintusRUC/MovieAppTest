using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsForMovieController : BaseController
    {
        private readonly RatingsForMovieBusinessService _ratingsForMovieBusinessService;

        public RatingsForMovieController(RatingsForMovieBusinessService ratingsForMovieBusinessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _ratingsForMovieBusinessService = ratingsForMovieBusinessService;
        }

        [HttpGet("Search", Name = "SearchRatingsforMovie")]
        public async Task<IActionResult> GetRatingsForMovie(
            [FromQuery] string tconst,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)

        {
            // Hent ratings for film baseret på tconst
            var ratings = await _ratingsForMovieBusinessService.GetRatingsForMovieAsync(tconst);
            if (ratings == null || ratings.Count == 0)
            {
                return NotFound("No matching results found");
            }
            var totalItems = ratings.Count;
            var pagedResults = ratings.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchRatingsforMovie", // Use the named link here
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}
