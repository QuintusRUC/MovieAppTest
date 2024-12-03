using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieApp.DataLayer.Services
{
    public class GetBookmarksDbService
    {
        private readonly MovieContext _dbContext;

        public GetBookmarksDbService(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BookmarkResult>> GetBookmarksForUserAsync(int userId)
        {
            // Kald SQL-funktionen get_bookmarks
            var query = $"SELECT * FROM get_bookmarks({userId})";

            // Brug FromSqlRaw til at hente resultaterne
            return await _dbContext.Set<BookmarkResult>()
                .FromSqlRaw(query)
                .ToListAsync();
        }
    }

    // Resultatmodel til get_bookmarks
    public class BookmarkResult
    {
        public int bookmark_id { get; set; }   // Matcher SQL-kolonnen 'bookmark_id'
        public int user_id { get; set; }       // Matcher SQL-kolonnen 'user_id'
        public string item_type { get; set; }  // Matcher SQL-kolonnen 'item_type'
        public string item_id { get; set; }    // Matcher SQL-kolonnen 'item_id'
        public string? annotation { get; set; } // Matcher SQL-kolonnen 'annotation'
    }

}
