using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class GetBookmarksDbBusinessService
    {
        private readonly GetBookmarksDbService _getBookmarksDbService;

        public GetBookmarksDbBusinessService(GetBookmarksDbService getBookmarksDbService)
        {
            _getBookmarksDbService = getBookmarksDbService;
        }

        // Metode til at hente brugerens bogmærker baseret på user_id
        public async Task<List<BookmarkResult>> GetBookmarksForUserAsync(int userId)
        {
            return await _getBookmarksDbService.GetBookmarksForUserAsync(userId);
        }
    }
}
