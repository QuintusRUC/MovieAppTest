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
    public class StringSearchDbController : BaseController
    {
        private readonly StringSearchDbBusinessService _stringSearchDbBusinessService;

        public StringSearchDbController(StringSearchDbBusinessService stringSearchDbBusinessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _stringSearchDbBusinessService = stringSearchDbBusinessService;
        }

        // API-endpoint til at hente søgeresultater
        [HttpGet("Search", Name = "SearchStringSearchDb")]
        public async Task<ActionResult<List<StringSearchResult>>> GetStringSearchResults(
            [FromQuery] string searchName,
            [FromQuery] int userId,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            var result = await _stringSearchDbBusinessService.GetStringSearchResultsAsync(searchName, userId);
            if (result == null || result.Count == 0)
            {
                return NotFound("No matching results found");
            }
            var totalItems = result.Count;
            var pagedResults = result.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchStringSearchDb", // Use the named link here
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}
