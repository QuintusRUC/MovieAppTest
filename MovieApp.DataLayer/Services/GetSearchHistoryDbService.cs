using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class GetSearchHistoryDbService
    {
        private readonly MovieContext _dbContext;

        public GetSearchHistoryDbService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Kald SQL-funktionen get_search_history
        public async Task<List<SearchHistoryResult>> GetSearchHistoryForUserAsync(int userId)
        {
            var query = $"SELECT * FROM get_search_history({userId})";

            // Brug FromSqlRaw til at hente resultaterne
            return await _dbContext.Set<SearchHistoryResult>()
                .FromSqlRaw(query)
                .ToListAsync();
        }
    }

    // Resultatmodel for søgehistorik
    public class SearchHistoryResult
    {
        public string search_term { get; set; }
        public DateTime search_date { get; set; }
    }
}
