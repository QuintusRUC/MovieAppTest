using Microsoft.AspNetCore.Mvc;
using MovieApp.BusinessLayer.Services;
using System.Threading.Tasks;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NameRatingController : ControllerBase
    {
        private readonly NameRatingBusinessService _nameRatingBusinessService;

        public NameRatingController(NameRatingBusinessService nameRatingBusinessService)
        {
            _nameRatingBusinessService = nameRatingBusinessService;
        }

        [HttpPost("Calculate")]
        public async Task<IActionResult> CalculateNameRating(string nconst)
        {
            var success = await _nameRatingBusinessService.CalculateNameRatingAsync(nconst);
            if (success)
            {
                return Ok("Name rating calculated successfully.");
            }
            return StatusCode(500, "Failed to calculate name rating.");
        }
    }
}
