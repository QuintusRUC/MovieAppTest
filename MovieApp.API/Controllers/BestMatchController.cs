using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MovieApp.BusinessLayer;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BestMatchController : BaseController
    {
        private readonly BestMatchBusinessService _bestMatchBusinessService;

        public BestMatchController(BestMatchBusinessService bestMatchBusinessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _bestMatchBusinessService = bestMatchBusinessService;
        }
        [HttpGet("Search", Name = "SearchBestMatch")]
        public async Task<IActionResult> GetBestMatch(
            [FromQuery] string keyword1,
            [FromQuery] string? keyword2 = null,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            var results = await _bestMatchBusinessService.GetBestMatchAsync(keyword1, keyword2);

            if (results == null || results.Count == 0)
            {
                return NotFound("No matching movies found.");
            }

            var totalItems = results.Count;
            var pagedResults = results.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchBestMatch", // Brug det navngivne link her
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }


    }
}
