using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer.Services;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StructuredStringSearchController : BaseController
    {
        private readonly StructuredStringSearchBusinessService _businessService;

        public StructuredStringSearchController(StructuredStringSearchBusinessService businessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _businessService = businessService;
        }

        [HttpGet("Search", Name = "SearchStructuredStringSearch")]
        public async Task<IActionResult> Search(
            string titleOfMovie,
            string plotDesc,
            string characterName,
            string actorName,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            var results = await _businessService.SearchAsync(titleOfMovie, plotDesc, characterName, actorName);
            if (results == null || results.Count == 0)
            {
                return NotFound("No matching results found");
            }
            var totalItems = results.Count;
            var pagedResults = results.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchStructuredStringSearch", // Use the named link here
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);

        }
    }
}
