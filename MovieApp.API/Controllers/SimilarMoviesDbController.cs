using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer;
using MovieApp.DataLayer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimilarMoviesDbController : BaseController
    {
        private readonly SimilarMoviesDbBusinessService _similarMoviesDbBusinessService;

        public SimilarMoviesDbController(SimilarMoviesDbBusinessService similarMoviesDbBusinessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _similarMoviesDbBusinessService = similarMoviesDbBusinessService;
        }

        // API-endpoint til at hente lignende film
        [HttpGet("Search", Name = "SearchSimilarMoviesDb")]
        public async Task<ActionResult<List<SimilarMoviesResult>>> GetSimilarMovies(
            [FromQuery] string movieTitle,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            var result = await _similarMoviesDbBusinessService.GetSimilarMoviesAsync(movieTitle);
            if (result == null || result.Count == 0)
            {
                return NotFound("No matching results found");
            }
            var totalItems = result.Count;
            var pagedResults = result.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchSimilarMoviesDb", // Use the named link here
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}
