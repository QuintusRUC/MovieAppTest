using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class StringSearchDbService
    {
        private readonly MovieContext _dbContext;

        public StringSearchDbService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Kald SQL-funktionen string_search
        public async Task<List<StringSearchResult>> GetStringSearchResultsAsync(string searchName, int userId)
        {
            var query = $"SELECT * FROM string_search('{searchName}', {userId})";
            return await _dbContext.Set<StringSearchResult>().FromSqlRaw(query).ToListAsync();
        }
    }

    // Markerer denne klasse som keyless, da det ikke er en entitet i databasens model
    [Keyless]
    public class StringSearchResult
    {
        public string Movie_id { get; set; }
        public string Movie_title { get; set; }
    }
}
