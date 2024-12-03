using MovieApp.DataLayer.Services;
using System.Threading.Tasks;

namespace MovieApp.BusinessLayer.Services
{
    public class NameRatingBusinessService
    {
        private readonly NameRatingService _nameRatingService;

        public NameRatingBusinessService(NameRatingService nameRatingService)
        {
            _nameRatingService = nameRatingService;
        }

        public async Task<bool> CalculateNameRatingAsync(string nconst)
        {
            return await _nameRatingService.CalculateNameRatingAsync(nconst);
        }
    }
}
