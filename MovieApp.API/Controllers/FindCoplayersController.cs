using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FindCoplayersController : BaseController
    {
        private readonly FindCoplayersBusinessService _findCoplayersBusinessService;

        public FindCoplayersController(FindCoplayersBusinessService findCoplayersBusinessService, LinkGenerator linkGenerator)
        : base(linkGenerator)
        {
            _findCoplayersBusinessService = findCoplayersBusinessService;
        }

        // API-endpoint til at finde medspillere baseret på skuespillerens navn
        [HttpGet("Search", Name = "SearchCoPlayers")]
        public async Task<IActionResult> GetCoplayers(
            [FromQuery] string actorName,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)
        {
            // Kald BusinessLayer for at finde medspillere
            var coplayers = await _findCoplayersBusinessService.GetCoplayersAsync(actorName);
            if (coplayers == null || coplayers.Count == 0)
            {
                return NotFound("No coplayers found for the given actor name.");
            }
            var totalItems = coplayers.Count;
            var pagedResults = coplayers.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchCoPlayers", // Brug det navngivne link her
                page,
                pageSize,
                totalItems,
                pagedResults
            );
            return Ok(paginatedResponse);
        }
    }
}
