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
    public class GetSearchHistoryDbController : BaseController
    {
        private readonly GetSearchHistoryDbBusinessService _getSearchHistoryDbBusinessService;

        public GetSearchHistoryDbController(GetSearchHistoryDbBusinessService getSearchHistoryDbBusinessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _getSearchHistoryDbBusinessService = getSearchHistoryDbBusinessService;
        }

        // API-endpoint til at hente søgehistorik for en bruger baseret på user_id
        [HttpGet("Search", Name = "SearchGetSearchHistoryDb")]
        public async Task<IActionResult> GetSearchHistory(
            [FromQuery] int userId,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            var searchHistory = await _getSearchHistoryDbBusinessService.GetSearchHistoryForUserAsync(userId);
            if (searchHistory == null || searchHistory.Count == 0)
            {
                return NotFound("No matching results found");
            }
            var totalItems = searchHistory.Count;
            var pagedResults = searchHistory.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchGetSearchHistoryDb",
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}
