using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class SimilarMoviesDbBusinessService
    {
        private readonly SimilarMoviesDbService _similarMoviesDbService;

        public SimilarMoviesDbBusinessService(SimilarMoviesDbService similarMoviesDbService)
        {
            _similarMoviesDbService = similarMoviesDbService;
        }

        // Metode til at hente de film, der er lignende
        public async Task<List<SimilarMoviesResult>> GetSimilarMoviesAsync(string movieTitle)
        {
            return await _similarMoviesDbService.GetSimilarMoviesAsync(movieTitle);
        }
    }
}
