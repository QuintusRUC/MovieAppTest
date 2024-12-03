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
    public class PersonWordsDbController : BaseController
    {
        private readonly PersonWordsDbBusinessService _personWordsDbBusinessService;

        public PersonWordsDbController(PersonWordsDbBusinessService personWordsDbBusinessService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _personWordsDbBusinessService = personWordsDbBusinessService;
        }

        // API-endpoint til at hente ord og hyppighed
        [HttpGet("Search", Name = "SearchPersonWordsDb")]
        public async Task<ActionResult<List<PersonWordsResult>>> GetPersonWords(
            [FromQuery] string nconst,
            [FromQuery] int maxLength,
            [FromQuery] int page = 0,
            [FromQuery] int pageSize = 10)

        {
            var result = await _personWordsDbBusinessService.GetPersonWordsAsync(nconst, maxLength);
            if (result == null || result.Count == 0)
            {
                return NotFound("No matching results found");
            }
            var totalItems = result.Count;
            var pagedResults = result.Skip(page * pageSize).Take(pageSize);

            var paginatedResponse = CreatePaging(
                "SearchPersonWordsDb",
                page,
                pageSize,
                totalItems,
                pagedResults
            );

            return Ok(paginatedResponse);
        }
    }
}
