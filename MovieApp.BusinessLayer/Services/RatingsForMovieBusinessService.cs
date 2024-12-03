using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class RatingsForMovieBusinessService
    {
        private readonly RatingsForMovieService _ratingsForMovieService;

        public RatingsForMovieBusinessService(RatingsForMovieService ratingsForMovieService)
        {
            _ratingsForMovieService = ratingsForMovieService;
        }

        public async Task<List<RatingsForMovieResult>> GetRatingsForMovieAsync(string tconst)
        {
            return await _ratingsForMovieService.GetRatingsForMovieAsync(tconst);
        }
    }
}
