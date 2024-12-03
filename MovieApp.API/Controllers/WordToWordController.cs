using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApp.BusinessLayer;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordToWordController : BaseController
    {
        private readonly WordToWordBusinessService _businessService;

        public WordToWordController(WordToWordBusinessService businessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _businessService = businessService;
        }
        [HttpGet("Search", Name = "SearchWordToWord")]
        public async Task<IActionResult> GetWords(
         [FromQuery] string keyword,
         [FromQuery] int page = 0,
         [FromQuery] int pageSize = 10)
        {
            var results = await _businessService.GetWordToWordAsync(keyword);
            if (results == null || results.Count == 0)
            {
                return NotFound("No matching results found.");
            }

            var totalItems = results.Count;
            var pagedResults = results.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchWordToWord", // Use the named link here
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}
