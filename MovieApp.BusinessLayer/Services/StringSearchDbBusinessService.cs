using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.DataLayer.Services;

namespace MovieApp.BusinessLayer
{
    public class StringSearchDbBusinessService
    {
        private readonly StringSearchDbService _stringSearchDbService;

        public StringSearchDbBusinessService(StringSearchDbService stringSearchDbService)
        {
            _stringSearchDbService = stringSearchDbService;
        }

        // Metode til at hente søgeresultater for string_search
        public async Task<List<StringSearchResult>> GetStringSearchResultsAsync(string searchName, int userId)
        {
            return await _stringSearchDbService.GetStringSearchResultsAsync(searchName, userId);
        }
    }
}
