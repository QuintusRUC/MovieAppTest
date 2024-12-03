using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class RateDbBusinessService
    {
        private readonly RateDbService _rateDbService;

        public RateDbBusinessService(RateDbService rateDbService)
        {
            _rateDbService = rateDbService;
        }

        // Metode til at rate en film
        public async Task RateMovieAsync(int userId, string movieId, int rating)
        {
            await _rateDbService.RateMovieAsync(userId, movieId, rating);
        }
    }
}
