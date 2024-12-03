using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MovieApp.BusinessLayer;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetBookmarksDbController : BaseController
    {
        private readonly GetBookmarksDbBusinessService _getBookmarksDbBusinessService;

        public GetBookmarksDbController(GetBookmarksDbBusinessService getBookmarksDbBusinessService, LinkGenerator linkGenerator)
            : base(linkGenerator) 
        {
            _getBookmarksDbBusinessService = getBookmarksDbBusinessService;
        }

        // API-endpoint til at hente bogmærker for en bruger baseret på user_id
        [HttpGet("Search", Name = "SearchGetBookmarks")]
        public async Task<IActionResult> GetBookmarkedItems(
            [FromQuery] int userId,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            // Kald BusinessLayer for at hente bogmærker
            var bookmarks = await _getBookmarksDbBusinessService.GetBookmarksForUserAsync(userId);
            if (bookmarks == null || bookmarks.Count == 0)
            {
                return NotFound("No bookmarks found for the given user.");
            }
            var totalItems = bookmarks.Count;
            var pagedResults = bookmarks.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchGetBookmarks", // Brug det navngivne link her
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}
