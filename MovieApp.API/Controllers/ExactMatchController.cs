using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MovieApp.BusinessLayer;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExactMatchController : BaseController
    {
        private readonly ExactMatchBusinessService _exactMatchBusinessService;

        public ExactMatchController(ExactMatchBusinessService exactMatchBusinessService, LinkGenerator linkGenerator)
        : base(linkGenerator)
        {
            _exactMatchBusinessService = exactMatchBusinessService;
        }

        // API-endpoint til at hente film baseret på to søgeord
        [HttpGet("Search", Name = "SearchExactMatch")]
        public async Task<IActionResult> GetExactMatchMovies(
            [FromQuery] string keyword1,
            [FromQuery] string keyword2 = null,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            // Kald BusinessLayer for at hente film
            var movies = await _exactMatchBusinessService.GetExactMatchMoviesAsync(keyword1, keyword2);
            if (movies == null || movies.Count == 0)
            {
                return NotFound("No movies found for the given keywords.");
            }

            var totalItems = movies.Count;
            var pagedResults = movies.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchExactMatch", // Brug det navngivne link her
                page,
                pageSize,
                totalItems,
                pagedResults
            );
            return Ok(paginatedResponse);
        }
    }
}
