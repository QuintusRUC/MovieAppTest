using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer.Services;
using MovieApp.DataLayer.Models;
using System.Threading.Tasks;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchHistoryController : ControllerBase
    {
        private readonly SearchHistoryBusinessService _searchHistoryBusinessService;

        public SearchHistoryController(SearchHistoryBusinessService searchHistoryBusinessService)
        {
            _searchHistoryBusinessService = searchHistoryBusinessService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSearchHistory()
        {
            var history = await _searchHistoryBusinessService.GetAllSearchHistoryAsync();
            return Ok(history);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSearchHistoryById(int id)
        {
            var entry = await _searchHistoryBusinessService.GetSearchHistoryByIdAsync(id);
            if (entry == null)
                return NotFound("Search history entry not found.");
            return Ok(entry);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddSearchHistory(int userId, string searchTerm, DateTime? searchDate = null)
        {
            var utcDate = (searchDate ?? DateTime.Now).ToUniversalTime(); // Konverter til UTC
            var entry = new SearchHistory
            {
                UserId = userId,
                SearchTerm = searchTerm,
                SearchDate = utcDate
            };

            var success = await _searchHistoryBusinessService.AddSearchHistoryAsync(entry);
            if (success)
                return Ok("Search history entry added successfully.");
            return StatusCode(500, "Failed to add search history entry.");
        }



        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSearchHistory(int searchId, int userId, string searchTerm, DateTime searchDate)
        {
            var success = await _searchHistoryBusinessService.UpdateSearchHistoryAsync(searchId, userId, searchTerm, searchDate);
            if (success)
                return Ok("Search history entry updated successfully.");
            return StatusCode(500, "Failed to update search history entry.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSearchHistory(int id)
        {
            var success = await _searchHistoryBusinessService.DeleteSearchHistoryAsync(id);
            if (success)
                return Ok("Search history entry deleted successfully.");
            return StatusCode(500, "Failed to delete search history entry.");
        }
    }
}
