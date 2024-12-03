using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class ExactMatchBusinessService
    {
        private readonly ExactMatchService _exactMatchService;

        public ExactMatchBusinessService(ExactMatchService exactMatchService)
        {
            _exactMatchService = exactMatchService;
        }

        // Metode til at hente film baseret på keyword1 og keyword2
        public async Task<List<ExactMatchResult>> GetExactMatchMoviesAsync(string keyword1, string keyword2 = null)
        {
            return await _exactMatchService.GetExactMatchMoviesAsync(keyword1, keyword2);
        }
    }
}
