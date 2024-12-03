using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class GetSearchHistoryDbBusinessService
    {
        private readonly GetSearchHistoryDbService _getSearchHistoryDbService;

        public GetSearchHistoryDbBusinessService(GetSearchHistoryDbService getSearchHistoryDbService)
        {
            _getSearchHistoryDbService = getSearchHistoryDbService;
        }

        // Metode til at hente søgehistorik for en bruger baseret på user_id
        public async Task<List<SearchHistoryResult>> GetSearchHistoryForUserAsync(int userId)
        {
            return await _getSearchHistoryDbService.GetSearchHistoryForUserAsync(userId);
        }
    }
}
