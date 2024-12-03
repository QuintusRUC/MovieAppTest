using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class BestMatchBusinessService
    {
        private readonly BestMatchService _bestMatchService;

        public BestMatchBusinessService(BestMatchService bestMatchService)
        {
            _bestMatchService = bestMatchService;
        }

        public async Task<List<BestMatchResult>> GetBestMatchAsync(string keyword1, string? keyword2 = null)
        {
            return await _bestMatchService.GetBestMatchAsync(keyword1, keyword2);
        }
    }
}
